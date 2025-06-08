using System.Collections;
using System.Security.Cryptography;
using Domain.Entities.Wallets;
using Microsoft.AspNetCore.Routing;
using Resources.Messages;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace Application.Features.Job.Commands.RechargeAdsClick;

public class RechargeAdsClickCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender, [FromServices] IZarinPalClient client,
    UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator,
    Logging.Base.ILogger<RechargeAdsClickCommandHandler> logger)
: IRequestHandler<RechargeAdsClickCommand, RechargeAdsClickViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected LinkGenerator LinkGenerator { get; } = linkGenerator;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<RechargeAdsClickCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<RechargeAdsClickViewModel>> Handle(RechargeAdsClickCommand request, CancellationToken cancellationToken)
    {
        #region ( Recharge AdsClick Action Command )

        var result = new FluentResults.Result<RechargeAdsClickViewModel>();
        var responseViewModel = new RechargeAdsClickViewModel();

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            #region ( Validations )

            if (HttpContext == null)
                return result.WithError(Resources.Messages.Validations.BadRequestException);

            if (request is { PortalId: <= 0 })
                return Result.Fail(Errors.NotSelectingPaymentMethod);

            if (HttpContext?.User.Identity is null or { IsAuthenticated: false })
                return Result.Fail(Validations.BadRequestException);

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Resources.Messages.Validations.BadRequestException);

            #endregion

            var userSubscription = await UnitOfWork.UserSubscriptionRepository.TableNoTracking
                .Where(a => a.IsActive && a.IsFinally && a.EndDate.Day > DateTime.Now.Day)
                .SingleOrDefaultAsync(a => a.UserId == request.UserId, cancellationToken: cancellationToken);

            if (userSubscription == null)
                return Result.Fail(Resources.Messages.Validations.NotFoundException);

            var paymentPortal = await UnitOfWork.PaymentPortalRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id == request.PortalId, cancellationToken: cancellationToken);
            if (paymentPortal == null) return Result.Fail(Errors.NotSelectingPaymentMethod);

            #region ( Calculate TotalChargeAmount )

            var price = request.Price;
            var giftChargePrice = request.GiftPrice;
            var totalChargeAmount = price + giftChargePrice;

            #endregion

            #region ( RechargeAdsClick Process )

            if (totalChargeAmount > 0)
            {
                switch (request.PortalId)
                {
                    case 1:
                    {
                        #region ( Zarinpal RechargeAdsClick Gateway )

                        var conf = await UnitOfWork.ConfigRepository.TableNoTracking
                            .Select(a => new { a.Domain, a.Tel, a.Email, a.ZarinpalMerchant, a.ZarinpalMode, a.ZarinpalUrl, a.ZarinpalCallbackUrl })
                            .FirstAsync(cancellationToken: cancellationToken);

                        var mode = Mode.SandBox;
                        if (conf.ZarinpalMode) mode = Mode.Operational;

                        var paymentClickRequest = new PaymentRequest()
                        {
                            MerchantId = conf.ZarinpalMerchant,
                            Amount = Convert.ToDecimal(totalChargeAmount * 10),
                            Email = conf.Email,
                            Mobile = conf.Tel,
                            Description = "افزایش شارژ پنل مدیریت کسب و کار راویل",
                            CallbackUrl = conf.ZarinpalCallbackUrl,
                            Mode = mode
                        };

                        var res = await client.SendAsync(paymentClickRequest, cancellationToken);
                        if (res.Status == ZarinPalDriver.Models.Status.Success)
                        {
                            #region ( Handle User Wallet )

                            var userWallet = await UnitOfWork.WalletRepository.Table
                                .SingleOrDefaultAsync(a => a.ApplicationUserId.Equals(request.UserId), cancellationToken: cancellationToken);

                            if (userWallet is null)
                            {
                                var newUserWallet = new Wallet
                                {
                                    Inventory = 0,
                                    ApplicationUserId = request.UserId,
                                };

                                await UnitOfWork.WalletRepository.InsertAsync(newUserWallet);
                                await UnitOfWork.SaveAsync();

                                userWallet = newUserWallet;
                            }

                            #endregion

                            #region ( Handle RechargeAdsClick Transactions )

                            var orderAuthCode = res.Authority.TrimStart('0');
                            var generateNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);

                            var newTransaction = new Transaction
                            {
                                Amount = $"{totalChargeAmount}",
                                Number = generateNumber,
                                AuthCode = orderAuthCode,
                                Status = TransactionStatus.Pending,
                            };

                            await UnitOfWork.TransactionRepository.InsertAsync(newTransaction);
                            await UnitOfWork.SaveAsync();

                            var walletTransaction = new WalletTransaction
                            {
                                IsConfirmed = false,
                                Amount = Convert.ToDouble(totalChargeAmount),
                                TransactionType = WalletTransactionType.Deposit,
                                CreateDate = DateTime.Now,
                                WalletId = userWallet.Id,
                                TransactionId = newTransaction.Id,
                            };

                            await UnitOfWork.WalletTransactionRepository.InsertAsync(walletTransaction);
                            await UnitOfWork.SaveAsync();

                            #endregion

                            responseViewModel.ReturnUrl = $"{conf.ZarinpalUrl}{res.Authority}";
                            responseViewModel.WalletTransactionId = walletTransaction.Id;
                            result.WithValue(responseViewModel);
                        }
                        else
                        {
                            Logger.LogError(message: res.Status.Message, parameters: new Hashtable
                            {
                                { nameof(res.Status.Code), res.Status.Code.ToString() }
                            });

                            result.WithError($"{res.Status.Message}. کد خطا: {res.Status.Code}");
                        }

                        #endregion
                    }
                    break;
                }
            }
            else
            {
                return result.WithError(Resources.Messages.Errors.ActionsHasError);
            }

            #endregion

            await UnitOfWork.SaveAsync();
            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            Logger.LogError(message: e.InnerException?.Message ?? e.Message);

            throw;
        }

        return result;

        #endregion
    }
}
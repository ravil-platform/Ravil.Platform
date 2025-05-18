using System.Collections;
using Microsoft.AspNetCore.Routing;
using Resources.Messages;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace Application.Features.Job.Commands.RechargeAdsClickVerification;

public class RechargeAdsClickVerificationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender, [FromServices] IZarinPalClient client,
    UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator,
    Logging.Base.ILogger<RechargeAdsClickVerificationCommandHandler> logger)
    : IRequestHandler<RechargeAdsClickVerificationCommand, RechargeAdsClickVerificationViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected LinkGenerator LinkGenerator { get; } = linkGenerator;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<RechargeAdsClickVerificationCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<RechargeAdsClickVerificationViewModel>> Handle(RechargeAdsClickVerificationCommand request, CancellationToken cancellationToken)
    {
        #region ( Recharge AdsClick Verification Command )

        var result = new FluentResults.Result<RechargeAdsClickVerificationViewModel>();
        var responseViewModel = new RechargeAdsClickVerificationViewModel();

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            #region ( Validations )

            if (HttpContext == null)
                return result.WithError(Resources.Messages.Validations.BadRequestException);

            if (HttpContext?.User.Identity is null or { IsAuthenticated: false })
                return Result.Fail(Validations.BadRequestException);

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            if (request is { PortalId: <= 0 })
                return Result.Fail(Errors.NotSelectingPaymentMethod);

            var paymentPortal = await UnitOfWork.PaymentPortalRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id == request.PortalId, cancellationToken: cancellationToken);
            if (paymentPortal == null) return Result.Fail(Errors.NotSelectingPaymentMethod);

            #endregion

            var walletTransaction = await UnitOfWork.WalletTransactionRepository.Table
                .Include(a => a.Wallet)
                .Include(a => a.Transaction)
                .SingleOrDefaultAsync(a => a.Id == request.WalletTransactionId, cancellationToken: cancellationToken);

            if (walletTransaction == null)
                return Result.Fail(Resources.Messages.Validations.BadRequestException);

            switch (request.PortalId)
            {
                //TODO Zarinpal
                case 1:
                {
                    #region ( Handle Zarinpal Gateway Payment )

                    var status = HttpContext.Request.Query[nameof(request.Status)];

                    if (!string.IsNullOrWhiteSpace(status) && status.ToString().ToLower() == "ok" &&
                        !string.IsNullOrWhiteSpace(HttpContext.Request.Query[nameof(request.Authority)]))
                    {
                        string authority = HttpContext.Request.Query[nameof(request.Authority)].ToString();
                        var transaction = await UnitOfWork.TransactionRepository.Table.SingleOrDefaultAsync(a => a.AuthCode != null && a.AuthCode.Equals(authority.TrimStart('0'))
                            && a.Status.Equals(TransactionStatus.Pending) && a.Id == walletTransaction.TransactionId, cancellationToken: cancellationToken);

                        if (transaction == null)
                            return Result.Fail(Resources.Messages.Validations.BadRequestException);

                        var config = await UnitOfWork.ConfigRepository.GetFirstAsync();

                        var mode = Mode.SandBox;
                        if (config.ZarinpalMode) mode = Mode.Operational;
                        var verificationRequest = new VerificationRequest
                        {
                            MerchantId = config.ZarinpalMerchant,
                            Amount = Convert.ToDecimal(walletTransaction.Amount * 10),
                            Authority = authority,
                            Mode = mode
                        };

                        var res = await client.SendAsync(verificationRequest, cancellationToken);
                        if (res.Status == Status.Success)
                        {
                            #region ( Handle Payment Transactions )

                            walletTransaction.IsConfirmed = true;
                            walletTransaction.Transaction.RefId = res.ReferenceId;
                            walletTransaction.Transaction.TransactionDate = DateTime.Now;
                            walletTransaction.Transaction.AuthCode = authority.TrimStart('0');
                            walletTransaction.Transaction.Status = TransactionStatus.Success;

                            await UnitOfWork.WalletTransactionRepository.UpdateAsync(walletTransaction);
                            await UnitOfWork.SaveAsync();

                            #endregion

                            #region ( Update RechargeAdsClick )

                            var userWallet = await UnitOfWork.WalletRepository.Table
                                .Include(a => a.WalletTransactions).ThenInclude(a => a.Transaction)
                                .SingleOrDefaultAsync(a => a.ApplicationUserId.Equals(businessOwnerId), cancellationToken: cancellationToken);

                            if (userWallet == null)
                                return Result.Fail(Resources.Messages.Validations.BadRequestException);

                            var totalHarvest = userWallet.WalletTransactions.Where(a => a is { IsConfirmed: true, Transaction.Status: TransactionStatus.Success })
                                .Where(a => a.TransactionType == WalletTransactionType.Harvest).Sum(a => a.Amount);
                                
                            var totalDeposit = userWallet.WalletTransactions.Where(a => a is { IsConfirmed: true, Transaction.Status: TransactionStatus.Success })
                                .Where(a => a.TransactionType == WalletTransactionType.Deposit).Sum(a => a.Amount);

                            userWallet.Inventory = totalDeposit - totalHarvest;
                            userWallet.Inventory += Convert.ToDouble(walletTransaction.Amount);
                            await UnitOfWork.WalletRepository.UpdateAsync(userWallet);

                            #endregion

                            #region ( Save Changes )

                            try
                            {
                                await UnitOfWork.SaveAsync();

                                //TODO Set Sms Pattern
                                #region ( Send SMS For Completed Order )

                                var r = await SmsSender.SendPattern(businessOwner.PhoneNumber ?? businessOwner.UserName!, $"{walletTransaction.Transaction.Number}|{businessOwner.Firstname} {businessOwner.Lastname}", SmsPatterns.OrderPayment);
                                var r2 = await SmsSender.SendPattern(config.OrderNotificationPhoneNumber!, walletTransaction.Transaction.Number, SmsPatterns.OrderAdmin);

                                #endregion

                                #region ( Set Payment Response ViewModel )

                                responseViewModel.PaymentAmount = walletTransaction.Amount.ToString("N0");
                                responseViewModel.PaymentStatusCode = res.Status.Code.ToString();
                                responseViewModel.PaymentStatusMessage = res.Status.Message;
                                responseViewModel.PaymentReferenceId = res.ReferenceId;
                                result.WithValue(responseViewModel);

                                #endregion
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                                result.WithError($"خطای ارتباط با سرور رخ داده است. در صورت کسر وجه با فروشگاه تماس حاصل فرمائید. کد پیگیری: {authority.TrimStart('0')}");
                            }

                            #endregion
                        }
                        else
                        {
                            #region ( Handle Payment Transactions )

                            transaction.Status = TransactionStatus.Failed;
                            transaction.RefId = res.Status.Code.ToString();
                            transaction.AuthCode = authority.TrimStart('0');
                                
                            await UnitOfWork.TransactionRepository.UpdateAsync(transaction);


                            walletTransaction.IsConfirmed = true;
                            await UnitOfWork.WalletTransactionRepository.UpdateAsync(walletTransaction);
                            await UnitOfWork.SaveAsync();

                            #endregion

                            #region ( Save Changes )

                            try
                            {
                                await UnitOfWork.SaveAsync();

                                result.WithError("پرداخت ناموفق");

                                #region ( Set Payment Response ViewModel )

                                responseViewModel.PaymentAmount = walletTransaction.Amount.ToString("N0");
                                responseViewModel.PaymentStatusCode = res.Status.Code.ToString();
                                responseViewModel.PaymentStatusMessage = res.Status.Message;
                                responseViewModel.PaymentReferenceId = res.ReferenceId;
                                result.WithValue(responseViewModel);

                                #endregion

                                #region ( Logging Payment Error )

                                if (res.Status.Code != 100)
                                {
                                    var parameters = new Hashtable();
                                    parameters.Add(nameof(responseViewModel.PaymentAmount), responseViewModel.PaymentAmount!);
                                    parameters.Add(nameof(responseViewModel.PaymentReferenceId), responseViewModel.PaymentReferenceId!);
                                    parameters.Add(nameof(responseViewModel.PaymentStatusCode), responseViewModel.PaymentStatusCode!);
                                    parameters.Add(nameof(responseViewModel.PaymentStatusMessage), responseViewModel.PaymentStatusMessage!);

                                    Logger.LogError(message: res.Status.Message, parameters: parameters);
                                }

                                #endregion
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                                result.WithError($"خطای ارتباط با سرور رخ داده است. در صورت کسر وجه با فروشگاه تماس حاصل فرمائید. کد پیگیری: {authority.TrimStart('0')}");
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        result.WithError("پرداخت ناموفق");
                    }

                    #endregion
                }
                break;
            }


            await UnitOfWork.SaveAsync();
            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);

            throw;
        }

        #endregion

        return result;
    }
}
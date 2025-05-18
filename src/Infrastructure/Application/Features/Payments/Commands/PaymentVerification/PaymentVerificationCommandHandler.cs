using System.Collections;
using System.Security.Cryptography;
using Domain.Entities.Wallets;
using Microsoft.AspNetCore.Routing;
using ViewModels.QueriesResponseViewModel.Payments;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace Application.Features.Payments.Commands.PaymentVerification;

public class PaymentVerificationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender, [FromServices] IZarinPalClient client,
    UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator,
    Logging.Base.ILogger<PaymentVerificationCommandHandler> logger)
    : IRequestHandler<PaymentVerificationCommand, PaymentVerificationResponseViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected LinkGenerator LinkGenerator { get; } = linkGenerator;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<PaymentVerificationCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<PaymentVerificationResponseViewModel>> Handle(PaymentVerificationCommand request, CancellationToken cancellationToken)
    {
        #region ( Payment Verification Command )

        var result = new FluentResults.Result<PaymentVerificationResponseViewModel>();
        var responseViewModel = new PaymentVerificationResponseViewModel();

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            if (HttpContext == null)
                return Result.Fail(Resources.Messages.Validations.BadRequestException);
            
            var userId = UserManager.GetUserId(HttpContext.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.GetByPredicate(a => a.Id == userId!, nameof(Wallet));
            if (businessOwner == null)
                return Result.Fail(Resources.Messages.Validations.BadRequestException);

            var payment = await UnitOfWork.PaymentRepository.Table
                .Include(a => a.PaymentPortal)
                .Include(a => a.UserSubscription)
                .ThenInclude(a => a.Subscription)
                .Include(a => a.PromotionCode)
                .SingleOrDefaultAsync(a => a.Id == request.PaymentId && a.PaymentPortalId == request.PortalId, cancellationToken: cancellationToken);

            if (payment == null) 
                return Result.Fail(Resources.Messages.Validations.BadRequestException);

            switch (request.PortalId)
            {
                //TODO Zarinpal
                case 1:
                    {
                        #region ( Handle Zarinpal Gateway Payment )

                        var status = HttpContext.Request.Query[nameof(request.Status)];

                        if (!string.IsNullOrWhiteSpace(status) && status.ToString().ToLower() == "ok"
                            && !string.IsNullOrWhiteSpace(HttpContext.Request.Query[nameof(request.Authority)]))
                        {
                            string authority = HttpContext.Request.Query[nameof(request.Authority)].ToString();
                            var transaction = await UnitOfWork.TransactionRepository.Table.SingleOrDefaultAsync(a => a.AuthCode != null && a.AuthCode.Equals(authority.TrimStart('0'))
                                && a.Status.Equals(TransactionStatus.Pending), cancellationToken: cancellationToken);

                            if (transaction == null) 
                                return Result.Fail(Resources.Messages.Validations.BadRequestException);

                            var config = await UnitOfWork.ConfigRepository.GetFirstAsync();

                            var mode = Mode.SandBox;
                            if (config.ZarinpalMode) mode = Mode.Operational;
                            var verificationRequest = new VerificationRequest
                            {
                                MerchantId = config.ZarinpalMerchant,
                                Amount = Convert.ToDecimal(payment.Amount * 10),
                                Authority = authority,
                                Mode = mode
                            };

                            var res = await client.SendAsync(verificationRequest, cancellationToken);
                            if (res.Status == Status.Success)
                            {
                                #region ( Handle Payment Transactions )

                                var pendingTransaction = await UnitOfWork.TransactionRepository.Table
                                    .SingleOrDefaultAsync(a => a.Status == TransactionStatus.Pending && a.PaymentId.Equals(payment.Id), cancellationToken: cancellationToken);

                                if (pendingTransaction is not null)
                                {
                                    pendingTransaction.PaymentId = payment.Id;
                                    pendingTransaction.RefId = res.ReferenceId;
                                    pendingTransaction.TransactionDate = DateTime.Now;
                                    pendingTransaction.AuthCode = authority.TrimStart('0');
                                    pendingTransaction.Status = TransactionStatus.Success;

                                    await UnitOfWork.TransactionRepository.UpdateAsync(pendingTransaction);
                                }
                                else
                                {
                                    var generateNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);
                                    
                                    var newTransaction = new Transaction
                                    {
                                        Amount = $"{payment.Amount}",
                                        Number = generateNumber,
                                        AuthCode = authority,
                                        PaymentId = payment.Id,
                                        RefId = res.ReferenceId,
                                        Status = TransactionStatus.Success,
                                        TransactionDate = DateTime.Now,
                                    };

                                    await UnitOfWork.TransactionRepository.InsertAsync(newTransaction);
                                    await UnitOfWork.SaveAsync();

                                    pendingTransaction = newTransaction;
                                    //return Result.Fail(Resources.Messages.Validations.BadRequestException);
                                }

                                #endregion

                                //TODO set Subscription Payment Number 
                                #region ( Update Subscription Number )
                                //generating booking number
                                /*if (string.IsNullOrWhiteSpace(payment.Number))
                                {
                                    payment.Number = config.OrderNumber.ToString();
                                    config.OrderNumber += 1;

                                    await UnitOfWork.ConfigRepository.UpdateAsync(config);
                                }*/
                                //end
                                #endregion

                                #region ( Update Payment And User Subscription )

                                var currentUserSubscription = await UnitOfWork.UserSubscriptionRepository.TableNoTracking
                                    .SingleOrDefaultAsync(current => current.Id == payment.UserSubscriptionId, cancellationToken: cancellationToken);

                                if (currentUserSubscription != null && currentUserSubscription.SubscriptionId == payment.UserSubscription.SubscriptionId)
                                {
                                    payment.UserSubscription.RenewalDate = DateTime.Now;
                                    payment.UserSubscription.BuyCount += 1;
                                }
                                
                                payment.UserSubscription.IsActive = true;
                                payment.UserSubscription.IsFinally = true;
                                payment.UserSubscription.UserId = businessOwner.Id;

                                await UnitOfWork.PaymentRepository.UpdateAsync(payment);

                                #endregion

                                #region ( Charge AdClick Wallet )

                                var giftCharge = payment.UserSubscription.Subscription.GiftCharge;
                                if (giftCharge > 0)
                                {
                                    //giftCharge /= 10;

                                    var chargeUserWallet = new WalletTransaction
                                    {
                                        IsConfirmed = true,
                                        Amount = giftCharge,
                                        CreateDate = DateTime.Now,
                                        WalletId = businessOwner.Wallet.Id,
                                        TransactionId = pendingTransaction.Id,
                                        TransactionType = WalletTransactionType.Deposit,
                                    };
                                    await UnitOfWork.WalletTransactionRepository.InsertAsync(chargeUserWallet);
                                }

                                #endregion

                                #region ( Save Changes )

                                try
                                {
                                    await UnitOfWork.SaveAsync();

                                    #region ( Send SMS For Completed Order )

                                    var r = await SmsSender.SendPattern(businessOwner.PhoneNumber ?? businessOwner.UserName!, $"{payment.Number}|{businessOwner.Firstname} {businessOwner.Lastname}", SmsPatterns.OrderPayment);
                                    var r2 = await SmsSender.SendPattern(config.OrderNotificationPhoneNumber!, payment.Number, SmsPatterns.OrderAdmin);

                                    #endregion

                                    #region ( Set Payment Response ViewModel )

                                    responseViewModel.PaymentAmount = payment.Amount.ToString("N0");
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

                                var pendingTransaction = await UnitOfWork.TransactionRepository.Table
                                    .SingleOrDefaultAsync(a => a.Status == TransactionStatus.Pending && a.PaymentId.Equals(payment.Id), cancellationToken: cancellationToken);

                                if (pendingTransaction is not null)
                                {
                                    pendingTransaction.PaymentId = payment.Id;
                                    pendingTransaction.Status = TransactionStatus.Failed;
                                    pendingTransaction.RefId = res.Status.Code.ToString();
                                    pendingTransaction.AuthCode = authority.TrimStart('0');

                                    await UnitOfWork.TransactionRepository.UpdateAsync(pendingTransaction);
                                }
                                else
                                {
                                    return Result.Fail(Resources.Messages.Validations.BadRequestException);
                                }

                                #endregion

                                //TODO set Subscription Payment Number 
                                #region ( Update Order Number )
                                //generating booking number
                                //if (string.IsNullOrWhiteSpace(payment.Number))
                                //{
                                //    payment.Number = config.OrderNumber.ToString();
                                //    config.OrderNumber += 1;

                                //    await UnitOfWork.ConfigRepository.UpdateAsync(config);
                                //}
                                //end
                                #endregion

                                #region ( Update Payment )

                                payment.PaymentDate = DateTime.Now;
                                await UnitOfWork.PaymentRepository.UpdateAsync(payment);

                                #endregion

                                #region ( Save Changes )

                                try
                                {
                                    await UnitOfWork.SaveAsync();

                                    result.WithError("پرداخت ناموفق");

                                    #region ( Set Payment Response ViewModel )

                                    responseViewModel.PaymentAmount = payment.Amount.ToString("N0");
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
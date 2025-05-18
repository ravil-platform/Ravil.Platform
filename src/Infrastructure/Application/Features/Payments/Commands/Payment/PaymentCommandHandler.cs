using System.Collections;
using System.Security.Cryptography;
using Domain.Entities.Subscription;
using Domain.Entities.Wallets;
using Microsoft.AspNetCore.Routing;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Payments;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace Application.Features.Payments.Commands.Payment;

public class PaymentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender, [FromServices] IZarinPalClient client,
    UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator,
    Logging.Base.ILogger<PaymentCommandHandler> logger)
    : IRequestHandler<PaymentCommand, PaymentActionResponseViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected LinkGenerator LinkGenerator { get; } = linkGenerator;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<PaymentCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<PaymentActionResponseViewModel>> Handle(PaymentCommand request, CancellationToken cancellationToken)
    {
        #region ( Payment Action Command )

        var result = new FluentResults.Result<PaymentActionResponseViewModel>();
        var responseViewModel = new PaymentActionResponseViewModel();

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            if (HttpContext == null) 
                return result.WithError(Resources.Messages.Validations.BadRequestException);

            if (request is { PortalId: <= 0 })
                return Result.Fail(Errors.NotSelectingPaymentMethod);

            var userId = UserManager.GetUserId(HttpContext.User);
            var businessOwner = await UserManager.FindByIdAsync(userId!);

            var subscription = await UnitOfWork.SubscriptionRepository.TableNoTracking
                .Include(a => a.UserSubscriptions)
                .SingleOrDefaultAsync(a => a.Id == request.SubscriptionId, cancellationToken: cancellationToken);

            if (subscription == null) 
                return Result.Fail(Resources.Messages.Validations.NotFoundException);

            var paymentPortal = await UnitOfWork.PaymentPortalRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id == request.PortalId, cancellationToken: cancellationToken);
            if (paymentPortal == null) return Result.Fail(Errors.NotSelectingPaymentMethod);

            #region ( Handle Payment And Subscription )

            #region ( Calculate TotalAmount )

            var price = subscription.Price;
            var discount = subscription.DiscountAmount ?? 0;
            var totalAmount = price - discount;

            #endregion

            #region ( Handle New User Subscription )

            int userSubscriptionId;
            Guid paymentUserSubscriptionId;

            var currentUserSubscription = await UnitOfWork.UserSubscriptionRepository.Table.Include(a => a.Payment)
                .SingleOrDefaultAsync(current => current.UserId == businessOwner!.Id && current.SubscriptionId == request.SubscriptionId && !current.IsFinally, cancellationToken: cancellationToken);

            if (currentUserSubscription is null)
            {
                #region ( First Buy User Subscription )

                var newSubscriptionPlan = new UserSubscription
                {
                    SubscriptionId = request.SubscriptionId,
                    UserId = businessOwner!.Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(subscription.DurationTime),
                    BuyCount = 1,
                    IsActive = true,
                    IsFinally = false,
                };
                await UnitOfWork.UserSubscriptionRepository.InsertAsync(newSubscriptionPlan);
                await UnitOfWork.SaveAsync();

                var paymentNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);
                var orderPayment = new Domain.Entities.Payment.Payment
                {
                    Amount = totalAmount,
                    Number = paymentNumber,
                    PaymentDate = DateTime.Now,
                    PaymentPortalId = paymentPortal.Id,
                    PaymentMethod = PaymentMethod.OnlinePortal,
                    UserSubscriptionId = newSubscriptionPlan.Id,
                };
                await UnitOfWork.PaymentRepository.InsertAsync(orderPayment);
                await UnitOfWork.SaveAsync();

                userSubscriptionId = newSubscriptionPlan.Id;
                paymentUserSubscriptionId = orderPayment.Id;

                #endregion
            }
            else
            {
                #region ( Current Open User Subscription )

                if (currentUserSubscription.SubscriptionId == request.SubscriptionId)
                {
                    #region ( Renewal Subscription )

                    currentUserSubscription.UserId = businessOwner!.Id;
                    currentUserSubscription.EndDate = DateTime.Now.AddDays(subscription.DurationTime);

                    await UnitOfWork.UserSubscriptionRepository.UpdateAsync(currentUserSubscription);
                    await UnitOfWork.SaveAsync();

                    userSubscriptionId = currentUserSubscription.Id;
                    paymentUserSubscriptionId = currentUserSubscription.Payment.Id;

                    #endregion
                }
                else
                {
                    #region ( Renewal New User Subscription )

                    var newSubscriptionPlan = new UserSubscription
                    {
                        SubscriptionId = request.SubscriptionId,
                        UserId = businessOwner!.Id,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(subscription.DurationTime),
                        BuyCount = 1,
                        IsActive = true,
                        IsFinally = false,
                    };
                    await UnitOfWork.UserSubscriptionRepository.InsertAsync(newSubscriptionPlan);
                    await UnitOfWork.SaveAsync();


                    var paymentNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);
                    var orderPayment = new Domain.Entities.Payment.Payment
                    {
                        Amount = totalAmount,
                        Number = paymentNumber,
                        PaymentDate = DateTime.Now,
                        PaymentPortalId = paymentPortal.Id,
                        PaymentMethod = PaymentMethod.OnlinePortal,
                        UserSubscriptionId = newSubscriptionPlan.Id,
                    };
                    await UnitOfWork.PaymentRepository.InsertAsync(orderPayment);
                    await UnitOfWork.SaveAsync();


                    currentUserSubscription.IsActive = false;
                    await UnitOfWork.UserSubscriptionRepository.UpdateAsync(currentUserSubscription);
                    await UnitOfWork.SaveAsync();

                    userSubscriptionId = newSubscriptionPlan.Id;
                    paymentUserSubscriptionId = orderPayment.Id;

                    #endregion
                }

                #endregion
            }

            #endregion

            #endregion

            //TODO Check Subscription Changes Feature
            #region ( Check Subscription Changes )

            //var thisDate = subscription.LastUpdateDate;

            //subscription = await UnitOfWork.OrderRepository.CheckOrderChanges(subscription);
            //if (thisDate != subscription!.LastUpdateDate)
            //{
            //    throw new AppException("با عرض پوزش در حال حاضر، تغییری در میزان قیمت به وجود آمده است. لطفا دوباره بررسی نمائید و در صورت تایید سفارش را تکمیل کنید.");
            //}

            //subscription = await UnitOfWork.OrderRepository.CheckOrderDiscountCoupon(subscription);
            //if (thisDate != subscription.LastUpdateDate)
            //{
            //    throw new AppException("کد تخفیف وارد شده در سبد سفارش شما منقضی و حذف شده است. لطفا بررسی نمائید و در صورت تایید سفارش را تکمیل کنید");
            //}

            #endregion

            //TODO Check DiscountCoupon Feature
            #region ( Check DiscountCoupon )

            /*if (subscription.Payment is not null)
            {
                if (subscription.Payment.DiscountCouponId.HasValue)
                {
                    var discountCouponId = subscription.Payment.DiscountCouponId.Value;
                    var discountCoupon = await UnitOfWork.DiscountCouponRepository.AsNoTrackingQueryable
                        .SingleOrDefaultAsync(a => a.Id.Equals(discountCouponId), cancellationToken: cancellationToken);

                    if (discountCoupon is not null)
                    {
                        var isUseThisCode = await UnitOfWork.PaymentRepository.AsNoTrackingQueryable.Include(a => a.Order)
                            .AnyAsync(a => a.DiscountCouponId.HasValue && a.DiscountCouponId.Equals(discountCouponId) && a.Order!.IsFinally, cancellationToken: cancellationToken);

                        if (isUseThisCode)
                        {
                            throw new AppException("کد وارد شده، یکبار مصرف است و امکان استفاده مجدد نیست.");
                        }

                        if (discountCoupon.Type.Equals(CouponsType.Amount))
                            totalAmount -= discountCoupon.Amount ?? 0.00;
                        else
                        {
                            var discountPercentAmount = totalAmount * discountCoupon.Amount / 100;
                            totalAmount -= discountPercentAmount ?? 0.00;
                        }
                    }
                }
            }*/

            #endregion

            #region ( Payment Process )

            var currentPayment = await UnitOfWork.PaymentRepository.TableNoTracking
                .Where(a => a.Id == paymentUserSubscriptionId && a.UserSubscriptionId == userSubscriptionId)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (currentPayment != null && (currentPayment.Amount > 0 || totalAmount > 0))
            {
                switch (request.PortalId)
                {
                    case 1:
                    {
                        #region ( Zarinpal Payment Gateway )

                        var conf = await UnitOfWork.ConfigRepository.TableNoTracking
                            .Select(a => new { a.Domain, a.Tel, a.Email, a.ZarinpalMerchant, a.ZarinpalMode, a.ZarinpalUrl, a.ZarinpalCallbackUrl })
                            .FirstAsync(cancellationToken: cancellationToken);

                        var mode = Mode.SandBox;
                        if (conf.ZarinpalMode) mode = Mode.Operational;
                        
                        var paymentRequest = new PaymentRequest
                        {
                            MerchantId = conf.ZarinpalMerchant,
                            Amount = Convert.ToDecimal(totalAmount * 10),
                            Email = conf.Email,
                            Mobile = conf.Tel,
                            Description = "خرید اشتراک عضویت ویژه پلتفرم راویل",
                            CallbackUrl = conf.ZarinpalCallbackUrl,
                            Mode = mode
                        };

                        var res = await client.SendAsync(paymentRequest, cancellationToken);
                        if (res.Status == ZarinPalDriver.Models.Status.Success)
                        {
                            #region ( Handle Payment Transactions )

                            var orderAuthCode = res.Authority.TrimStart('0');
                            var generateNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);

                            var pendingTransaction = await UnitOfWork.TransactionRepository.Table
                                .SingleOrDefaultAsync(a => a.Status == TransactionStatus.Pending && a.PaymentId.Equals(currentPayment.Id), cancellationToken: cancellationToken);

                            if (pendingTransaction is not null)
                            {
                                pendingTransaction.Amount = $"{totalAmount}";
                                pendingTransaction.Number = generateNumber;
                                pendingTransaction.AuthCode = orderAuthCode;
                                pendingTransaction.PaymentId = currentPayment.Id;
                                pendingTransaction.Status = TransactionStatus.Pending;

                                await UnitOfWork.TransactionRepository.UpdateAsync(pendingTransaction);
                            }
                            else
                            {
                                var newTransaction = new Transaction
                                {
                                    Amount = $"{totalAmount}",
                                    Number = generateNumber,
                                    AuthCode = orderAuthCode,
                                    PaymentId = currentPayment.Id,
                                    Status = TransactionStatus.Pending,
                                };

                                await UnitOfWork.TransactionRepository.InsertAsync(newTransaction);
                                await UnitOfWork.SaveAsync();
                            }

                            #endregion

                            #region ( Update Payment )

                            currentPayment.Amount = totalAmount;
                            //currentPayment.DiscountAmount = discount;
                            //currentPayment.Discount = discount / price * 100; //TODO Set TotalDiscountAmount & TotalDiscount To Payment model
                            currentPayment.PaymentPortalId = paymentPortal.Id;
                            currentPayment.PaymentMethod = PaymentMethod.OnlinePortal;

                            await UnitOfWork.PaymentRepository.UpdateAsync(currentPayment);

                            #endregion

                            responseViewModel.ReturnUrl = $"{conf.ZarinpalUrl}{res.Authority}";
                            responseViewModel.PaymentId = currentPayment.Id;
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
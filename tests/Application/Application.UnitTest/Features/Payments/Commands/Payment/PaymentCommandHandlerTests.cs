using System.Linq.Expressions;
using System.Security.Claims;
using Application.Features.Payments.Commands.Payment;
using Application.Services.SMS;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Application.UnitTest.Helpers;
using Domain.Entities.Payment;
using Domain.Entities.Subscription;
using Domain.Entities.User;
using Domain.Entities.Wallets;
using FluentAssertions;
using Logging.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace Application.UnitTest.Features.Payments.Commands.Payment;

[Collection(CollectionDefinition.SharedFixture)]
public class PaymentCommandHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly ISmsSender _smsSender;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IZarinPalClient _zarinPalClient;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly LinkGenerator _linkGenerator;
    private readonly ILogger<PaymentCommandHandler> _logger;
    private readonly PaymentCommandHandler _handler;

    public PaymentCommandHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _smsSender = Substitute.For<ISmsSender>();
        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _zarinPalClient = Substitute.For<IZarinPalClient>();
        //_userManager = SubstituteHelper.CreateUserManager<ApplicationUser>();
        _linkGenerator = Substitute.For<LinkGenerator>();
        _logger = Substitute.For<ILogger<PaymentCommandHandler>>();

        _handler = new PaymentCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _smsSender,
            _zarinPalClient,
            _userManager,
            _httpContextAccessor,
            _linkGenerator,
            _logger
        );

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnError_When_HttpContextIsNull() { /*...*/ }
    [Fact]
    public async Task Should_ReturnError_When_PortalIdInvalid() { /*...*/ }
    [Fact]
    public async Task Should_ReturnError_When_SubscriptionNotFound() { /*...*/ }
    [Fact]
    public async Task Should_ReturnError_When_PaymentPortalNotFound() { /*...*/ }

    [Fact]
    public async Task Should_ReturnZarinpalUrl_When_PaymentSuccess()
    {
        //// Arrange
        //var context = new DefaultHttpContext();
        //context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user1") }, "mock"));
        //_httpContextAccessor.HttpContext.Returns(context);
        //_userManager.GetUserId(context.User).Returns("user1");
        //_userManager.FindByIdAsync("user1").Returns(new ApplicationUser { Id = "user1" });

        //var subscription = new Subscription { Id = 1, Price = 100000, DurationTime = 30 };
        //_sharedFixture.UnitOfWork.SubscriptionRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<Subscription, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(subscription);

        //var paymentPortal = new PaymentPortal { Id = 1 };
        //_sharedFixture.UnitOfWork.PaymentPortalRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<PaymentPortal, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(paymentPortal);

        //var userSubscription = new UserSubscription
        //{
        //    Id = 123,
        //    SubscriptionId = 1,
        //    UserId = "user1",
        //    IsFinally = false,
        //    IsActive = true,
        //    StartDate = DateTime.UtcNow,
        //    EndDate = DateTime.UtcNow.AddDays(30)
        //};
        //_sharedFixture.UnitOfWork.UserSubscriptionRepository.Table
        //    .Include(Arg.Any<string>()).Returns(_sharedFixture.UnitOfWork.UserSubscriptionRepository.Table);
        //_sharedFixture.UnitOfWork.UserSubscriptionRepository.Table
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<UserSubscription, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns((UserSubscription)null);

        //_sharedFixture.UnitOfWork.UserSubscriptionRepository.InsertAsync(Arg.Any<UserSubscription>()).Returns(Task.CompletedTask);
        //_sharedFixture.UnitOfWork.PaymentRepository.InsertAsync(Arg.Any<Domain.Entities.Payment.Payment>()).Returns(Task.CompletedTask);
        //_sharedFixture.UnitOfWork.SaveAsync().Returns(1);

        //var conf = new { Domain = "test.ir", Tel = "0939", Email = "info@test.ir", ZarinpalMerchant = "merchant", ZarinpalMode = true, ZarinpalUrl = "https://zarinpal.com/pg/StartPay/", ZarinpalCallbackUrl = "https://callback.test" };
        //_sharedFixture.UnitOfWork.ConfigRepository.TableNoTracking
        //    .Select(Arg.Any<Expression<Func<Domain.Entities.Config.Config, object>>>())
        //    .FirstAsync(Arg.Any<CancellationToken>())
        //    .Returns(conf);

        //_sharedFixture.UnitOfWork.PaymentRepository.TableNoTracking
        //    .Where(Arg.Any<Expression<Func<Domain.Entities.Payment.Payment, bool>>>())
        //    .SingleOrDefaultAsync(Arg.Any<CancellationToken>())
        //    .Returns(new Domain.Entities.Payment.Payment { Id = Guid.NewGuid(), Amount = 100000, UserSubscriptionId = 123 });

        ////_zarinPalClient.SendAsync(Arg.Any<PaymentRequest>(), Arg.Any<CancellationToken>())
        ////    .Returns(new PaymentResponse
        ////    {
        ////        Status = new Status { Code = 100, Message = "Success" },
        ////        Authority = "A00001234"
        ////    });

        //_sharedFixture.UnitOfWork.TransactionRepository.InsertAsync(Arg.Any<Transaction>()).Returns(Task.CompletedTask);
        //_sharedFixture.UnitOfWork.PaymentRepository.UpdateAsync(Arg.Any<Domain.Entities.Payment.Payment>()).Returns(Task.CompletedTask);

        //var request = new PaymentCommand { SubscriptionId = 1, PortalId = 1 };

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().NotBeNull();
        //result.Value.ReturnUrl.Should().StartWith("https://zarinpal.com/pg/StartPay/");
    }

    [Fact]
    public async Task Should_LogErrorAndReturnFail_When_ZarinpalFails()
    {
        //// Arrange
        //var context = new DefaultHttpContext();
        //context.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "user1") }, "mock"));
        //_httpContextAccessor.HttpContext.Returns(context);
        //_userManager.GetUserId(context.User).Returns("user1");
        //_userManager.FindByIdAsync("user1").Returns(new ApplicationUser { Id = "user1" });

        //var subscription = new Subscription { Id = 1, Price = 100000, DurationTime = 30 };
        //_sharedFixture.UnitOfWork.SubscriptionRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<Subscription, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(subscription);

        //var paymentPortal = new PaymentPortal { Id = 1 };
        //_sharedFixture.UnitOfWork.PaymentPortalRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<PaymentPortal, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(paymentPortal);

        ////_zarinPalClient.SendAsync(Arg.Any<PaymentRequest>(), Arg.Any<CancellationToken>())
        ////    .Returns(new PaymentResponse
        ////    {
        ////        Status = new Status { Code = -1, Message = "خطای پرداخت" },
        ////        Authority = ""
        ////    });

        //var request = new PaymentCommand { SubscriptionId = 1, PortalId = 1 };

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeFalse();
        //result.Errors.Should().Contain(e => e.Message.Contains("خطای پرداخت"));
    }
}
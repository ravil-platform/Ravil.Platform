#region ( namespaces )
using System.Linq.Expressions;
using System.Security.Claims;
using Application.Features.Payments.Commands.PaymentVerification;
using Application.Services.SMS;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.User;
using FluentAssertions;
using Logging.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using MockQueryable;
using NSubstitute;
using ZarinPalDriver;
#endregion

namespace Application.UnitTest.Features.Payments.Commands.PaymentVerification;

[Collection(CollectionDefinition.SharedDistributedCacheFixture)]
public class PaymentVerificationCommandHandlerTests
{
    #region ( Setup Fixture )
    private readonly SharedFixture _sharedFixture;
    private readonly DistributedCacheFixture _cacheFixture;
    private readonly PaymentVerificationCommandHandler _handler;

    public PaymentVerificationCommandHandlerTests(SharedFixture sharedFixture, DistributedCacheFixture cacheFixture)
    {
        _sharedFixture = sharedFixture;
        _cacheFixture = cacheFixture;

        var smsSender = Substitute.For<ISmsSender>();
        var zarinPalClient = Substitute.For<IZarinPalClient>();
        var userManager = Substitute.For<UserManager<ApplicationUser>>(
            Substitute.For<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        var linkGenerator = Substitute.For<LinkGenerator>();
        var logger = Substitute.For<ILogger<PaymentVerificationCommandHandler>>();

        var httpContext = new DefaultHttpContext();
        httpContextAccessor.HttpContext.Returns(httpContext);

        _handler = new PaymentVerificationCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            smsSender,
            zarinPalClient,
            userManager,
            httpContextAccessor,
            linkGenerator,
            logger,
            _cacheFixture.DistributedCache);
    }
    #endregion

    #region ( Should Return Error When Business Owner Is Null )
    [Fact]
    public async Task Should_ReturnError_When_BusinessOwnerIsNull()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.User = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "test-user") }, "mock"));

        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        httpContextAccessor.HttpContext.Returns(context);

        var userManager = Substitute.For<UserManager<ApplicationUser>>(
            Substitute.For<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
        userManager.GetUserId(Arg.Any<ClaimsPrincipal>()).Returns("test-user");

        _sharedFixture.UnitOfWork.ApplicationUserRepository.GetByPredicate(
                Arg.Any<Expression<Func<ApplicationUser, bool>>>(),
                Arg.Any<string?>())
            .Returns((ApplicationUser?)null);

        var handler = new PaymentVerificationCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            Substitute.For<ISmsSender>(),
            Substitute.For<IZarinPalClient>(),
            userManager,
            httpContextAccessor,
            Substitute.For<LinkGenerator>(),
            Substitute.For<ILogger<PaymentVerificationCommandHandler>>(),
            _cacheFixture.DistributedCache);

        var request = new PaymentVerificationCommand { PaymentId = Guid.NewGuid(), PortalId = 1 };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsFailed.Should().BeTrue();
    }
    #endregion

    #region ( Should Return Error When Payment Not Found ) 
    [Fact]
    public async Task Should_ReturnError_When_PaymentNotFound()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.User = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "test-user") }, "mock"));

        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        httpContextAccessor.HttpContext.Returns(context);

        var userManager = Substitute.For<UserManager<ApplicationUser>>(
            Substitute.For<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
        userManager.GetUserId(Arg.Any<ClaimsPrincipal>()).Returns("test-user");

        _sharedFixture.UnitOfWork.ApplicationUserRepository.GetByPredicate(
                Arg.Any<Expression<Func<ApplicationUser, bool>>>(),
                Arg.Any<string?>())
            .Returns(new ApplicationUser());

        _sharedFixture.UnitOfWork.PaymentRepository.Table
            .Returns(Enumerable.Empty<Domain.Entities.Payment.Payment>().AsQueryable().BuildMock());

        var handler = new PaymentVerificationCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            Substitute.For<ISmsSender>(),
            Substitute.For<IZarinPalClient>(),
            userManager,
            httpContextAccessor,
            Substitute.For<LinkGenerator>(),
            Substitute.For<ILogger<PaymentVerificationCommandHandler>>(),
            _cacheFixture.DistributedCache);

        var request = new PaymentVerificationCommand { PaymentId = Guid.NewGuid(), PortalId = 1 };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsFailed.Should().BeTrue();
    }
    #endregion
}
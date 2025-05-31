using System.Security.Claims;
using Application.Features.MessageBox.Commands.ReadAllMessages;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Application.UnitTest.Helpers;
using Domain.Entities.User;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using Resources.Messages;

namespace Application.UnitTest.Features.MessageBox.Commands.ReadAllMessages;

[Collection(CollectionDefinition.SharedFixture)]
public class ReadAllMessagesCommandHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly ReadAllMessagesCommandHandler _handler;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Logging.Base.ILogger<ReadAllMessagesCommandHandler> _logger;

    public ReadAllMessagesCommandHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;

        //_userManager = SubstituteHelper.CreateUserManager<ApplicationUser>();
        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _logger = Substitute.For<Logging.Base.ILogger<ReadAllMessagesCommandHandler>>();

        _handler = new ReadAllMessagesCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _userManager,
            _httpContextAccessor,
            _logger
        );

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnFailResult_WhenUserIsNotAuthenticated()
    {
        // Arrange
        var identity = Substitute.For<ClaimsIdentity>();
        identity.IsAuthenticated.Returns(false);

        var principal = new ClaimsPrincipal(identity);
        var context = new DefaultHttpContext { User = principal };
        _httpContextAccessor.HttpContext.Returns(context);

        var command = new ReadAllMessagesCommand();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        //result.Errors.Should().Contain(Validations.BadRequestException);
    }
}
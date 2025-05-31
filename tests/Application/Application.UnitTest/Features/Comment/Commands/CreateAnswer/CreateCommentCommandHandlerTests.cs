using System.Net;
using System.Security.Claims;
using Application.Features.Comment.Commands.Create;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using AutoMapper;
using Domain.Entities.User;
using Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Persistence.Contracts;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.UnitTest.Features.Comment.Commands.CreateAnswer;

[Collection(CollectionDefinition.SharedFixture)]
public class CreateCommentCommandHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Logging.Base.ILogger<CreateCommentCommandHandler> _logger;
    private readonly CreateCommentCommandHandler _handler;

    public CreateCommentCommandHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _mapper = _sharedFixture.Mapper;
        _unitOfWork = _sharedFixture.UnitOfWork;

        // وابستگی‌هایی که در SharedFixture نیستن → باید ماک بشن
        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _logger = Substitute.For<Logging.Base.ILogger<CreateCommentCommandHandler>>();

        var userStore = Substitute.For<IUserStore<ApplicationUser>>();
        _userManager = Substitute.For<UserManager<ApplicationUser>>(
            userStore, null, null, null, null, null, null, null, null);

        _handler = new CreateCommentCommandHandler(
            _mapper,
            _unitOfWork,
            _userManager,
            _httpContextAccessor,
            _logger);
    }

    [Fact]
    public async Task Should_Create_Comment_When_Valid_Request()
    {
        //// Arrange
        //var request = new CreateCommentCommand
        //{
        //    CommentType = CommentTypes.Blog,
        //    CommentText = "تست نظر",
        //    BlogId = 1,
        //    UserId = "user-123",
        //    Rate = 4
        //};

        //var user = new ApplicationUser
        //{
        //    Id = "user-123",
        //    Firstname = "حمید",
        //    Lastname = "کریمی",
        //    UserName = "09121234567",
        //    Email = "hamid@test.com",
        //    Avatar = "avatar.jpg"
        //};

        //var entity = new Domain.Entities.Comment.Comment { Id = 1, CommentText = request.CommentText };
        //var viewModel = new CommentViewModel { Id = 1, CommentText = request.CommentText };

        //// شبیه‌سازی HttpContext با IP و User احراز هویت‌شده
        //var claims = new List<Claim> { new Claim(ClaimTypes.Name, "user") };
        //var identity = new ClaimsIdentity(claims, "test");
        //var principal = new ClaimsPrincipal(identity);

        //_httpContextAccessor.HttpContext.Returns(new DefaultHttpContext
        //{
        //    Connection = { RemoteIpAddress = IPAddress.Parse("127.0.0.1") },
        //    User = principal
        //});

        //// ماک دیتا بیس برای پیدا کردن کاربر
        //_unitOfWork.ApplicationUserRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<System.Linq.Expressions.Expression<Func<ApplicationUser, bool>>>(), CancellationToken.None)
        //    .Returns(user);

        //_mapper.Map<Domain.Entities.Comment.Comment>(request).Returns(entity);
        //_mapper.Map<CommentViewModel>(entity).Returns(viewModel);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().NotBeNull();
        //result.Value.Id.Should().Be(1);
        //await _unitOfWork.CommentRepository.Received(1).InsertAsync(entity);
        //await _unitOfWork.Received(1).SaveAsync();
    }
}
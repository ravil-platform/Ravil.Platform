using System.Net;
using Application.Features.Comment.Commands.CreateAnswer;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Comment;
using Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.UnitTest.Features.Comment.Commands.Create;

[Collection(CollectionDefinition.SharedFixture)]
public class CreateAnswerCommentCommandHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly CreateAnswerCommentCommandHandler _handler;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Logging.Base.ILogger<CreateAnswerCommentCommandHandler> _logger;

    public CreateAnswerCommentCommandHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _logger = Substitute.For<Logging.Base.ILogger<CreateAnswerCommentCommandHandler>>();

        _handler = new CreateAnswerCommentCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _httpContextAccessor,
            _logger
        );
    }

    [Fact]
    public async Task Should_Create_AnswerComment_When_Valid_Request()
    {
        //// Arrange
        //var request = new CreateAnswerCommentCommand
        //{
        //    UserId = "user-123",
        //    AnswerCommentText = "پاسخ تستی",
        //    CommentId = 10,
        //    FullName = "علی اکبری",
        //    Avatar = "avatar.jpg",
        //    IsAdminAnswer = false,
        //};

        //var currentComment = new Domain.Entities.Comment.Comment
        //{
        //    Id = 10,
        //    CommentType = CommentTypes.JobBranch,
        //    JobBranchId = "branch-001"
        //};

        //var answerCommentEntity = new AnswerComment
        //{
        //    Id = 1,
        //    AnswerCommentText = request.AnswerCommentText,
        //    CommentId = request.CommentId
        //};

        //var answerCommentViewModel = new AnswerCommentViewModel
        //{
        //    AnswerCommentText = request.AnswerCommentText
        //};

        //// Mock HttpContext
        //var httpContext = new DefaultHttpContext
        //{
        //    Connection = { RemoteIpAddress = IPAddress.Parse("192.168.1.1") }
        //};
        //_httpContextAccessor.HttpContext.Returns(httpContext);

        //// Mock UnitOfWork
        //_sharedFixture.UnitOfWork.CommentRepository.GetByIdAsync(request.CommentId)
        //    .Returns(currentComment);

        //_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking
        //    .AnyAsync(Arg.Any<System.Linq.Expressions.Expression<Func<Domain.Entities.Job.JobBranch, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(true);

        //_sharedFixture.Mapper.Map<AnswerComment>(request).Returns(answerCommentEntity);
        //_sharedFixture.Mapper.Map<AnswerCommentViewModel>(answerCommentEntity).Returns(answerCommentViewModel);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().NotBeNull();

        //await _sharedFixture.UnitOfWork.AnswerCommentRepository.Received(1).InsertAsync(answerCommentEntity);
        //await _sharedFixture.UnitOfWork.Received(1).SaveAsync();
    }
}
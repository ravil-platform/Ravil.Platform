using Application.Features.Comment.Queries.GetAllAnswersByCommentId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Comment;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.UnitTest.Features.Comment.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAnswersByCommentIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAnswersByCommentIdQueryHandler _handler;

    public GetAnswersByCommentIdQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetAnswersByCommentIdQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_Answers_When_Valid_CommentId()
    {
        //// Arrange
        //var request = new GetAnswersByCommentIdQuery
        //{
        //    CommentId = 123
        //};

        //var answers = new List<AnswerComment>
        //{
        //    new AnswerComment { Id = 1, CommentId = 123, AnswerCommentText = "پاسخ ۱" },
        //    new AnswerComment { Id = 2, CommentId = 123, AnswerCommentText = "پاسخ ۲" }
        //};

        //var viewModels = new List<AnswerCommentViewModel>
        //{
        //    new AnswerCommentViewModel {  AnswerCommentText = "پاسخ ۱" },
        //    new AnswerCommentViewModel {  AnswerCommentText = "پاسخ ۲" }
        //};

        ////_sharedFixture.UnitOfWork.AnswerCommentRepository
        ////    .GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<Func<AnswerComment, bool>>>())
        ////    .Returns(Task.FromResult(answers));

        //_sharedFixture.Mapper.Map<List<AnswerCommentViewModel>>(answers).Returns(viewModels);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(2);
        //result.Value.First().AnswerCommentText.Should().Be("پاسخ ۱");
    }
}
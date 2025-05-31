using Application.Features.Comment.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.UnitTest.Features.Comment.Queries.GetAllAnswersByCommentId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetCommentsByFilterQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetCommentsByFilterQueryHandler _handler;

    public GetCommentsByFilterQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetCommentsByFilterQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_Filtered_Comments_When_IsConfirmed_Is_True()
    {
        //// Arrange
        //var request = new GetCommentsByFilterQuery
        //{
        //    IsConfirmed = true
        //};

        //var comments = new List<Domain.Entities.Comment.Comment>
        //{
        //    new Domain.Entities.Comment.Comment { Id = 1, IsConfirmed = true, CommentText = "کامنت تأیید شده" }
        //};

        //var viewModels = new List<CommentViewModel>
        //{
        //    new CommentViewModel { Id = 1, CommentText = "کامنت تأیید شده" }
        //};

        //_sharedFixture.UnitOfWork.CommentRepository.TableNoTracking
        //    .Returns(comments.AsQueryable());

        //_sharedFixture.Mapper.Map<List<CommentViewModel>>(comments).Returns(viewModels);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(1);
        //result.Value.First().CommentText.Should().Be("کامنت تأیید شده");
    }
}
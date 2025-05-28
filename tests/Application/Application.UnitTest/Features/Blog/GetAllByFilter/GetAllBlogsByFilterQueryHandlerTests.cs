using Application.Features.Blog.Queries.GetAllByFilter;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using AutoMapper;
using Domain.Entities.User;
using FluentAssertions;
using NSubstitute;
using ViewModels.Filter.Blog;

namespace Application.UnitTest.Features.Blog.GetAllByFilter;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllBlogsByFilterQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllBlogsByFilterQueryHandler _handler;

    public GetAllBlogsByFilterQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllBlogsByFilterQueryHandler(_sharedFixture.UnitOfWork, _sharedFixture.Mapper);
    }

    [Fact]
    public async Task Should_ReturnBlogFilterViewModel_WithCorrectCountAndEntities()
    {
        // Arrange
        var request = new GetAllBlogsByFilterQuery
        {
        };

        var blogs = new List<Domain.Entities.Blog.Blog>
        {
            new Domain.Entities.Blog.Blog { Id = 1, Title = "Blog 1",
                BlogUserLikes = new List<UserBlogLike>
                {
                    new UserBlogLike
                    {
                        Id = 1,
                        LikeTimeDate = DateTime.Now,
                        UserId = Guid.NewGuid().ToString(),
                        BlogId = 1,
                    }
                }
            }
        }.AsQueryable();

        var blogFilterViewModelMock = Substitute.ForPartsOf<BlogFilterViewModel>();

        blogFilterViewModelMock.Build(blogs.Count());
        blogFilterViewModelMock.SetEntities(blogs, _sharedFixture.Mapper);

        _sharedFixture.Mapper.Map<BlogFilterViewModel>(request).Returns(blogFilterViewModelMock);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeSameAs(blogFilterViewModelMock);
    }
}
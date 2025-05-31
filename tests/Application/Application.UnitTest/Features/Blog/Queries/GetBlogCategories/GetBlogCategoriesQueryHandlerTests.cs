using Application.Features.Blog.Queries.GetBlogCategories;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Common.Exceptions;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.UnitTest.Features.Blog.Queries.GetBlogCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GetBlogCategoriesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetBlogCategoriesQueryHandler _handler;

    public GetBlogCategoriesQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetBlogCategoriesQueryHandler(_sharedFixture.UnitOfWork, _sharedFixture.Mapper);
    }

    [Fact]
    public async Task Should_ThrowNotFoundException_WhenNoBlogCategoriesFound()
    {
        // Arrange
        _sharedFixture.UnitOfWork.BlogCategoryRepository.GetAllAsync()!
            .Returns(Task.FromResult<ICollection<Domain.Entities.Blog.BlogCategory>>(new List<Domain.Entities.Blog.BlogCategory>()));

        var query = new GetBlogCategoriesQuery();

        // Act & Assert
        await FluentActions.Invoking(() => _handler.Handle(query, CancellationToken.None))
            .Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Should_ReturnMappedBlogCategoryViewModels_WhenBlogCategoriesExist()
    {
        // Arrange
        var blogCategories = new List<Domain.Entities.Blog.BlogCategory>
        {
            new Domain.Entities.Blog.BlogCategory { Id = 1, Title = "Category1" },
            new Domain.Entities.Blog.BlogCategory { Id = 2, Title = "Category2" }
        };

        var blogCategoryViewModels = new List<BlogCategoryViewModel>
        {
            new BlogCategoryViewModel { Title = "Category1" },
            new BlogCategoryViewModel { Title = "Category2" }
        };

        _sharedFixture.UnitOfWork.BlogCategoryRepository.GetAllAsync()!
            .Returns(Task.FromResult<IList<Domain.Entities.Blog.BlogCategory>>(blogCategories));

        _sharedFixture.Mapper.Map<List<BlogCategoryViewModel>>(blogCategories)
            .Returns(blogCategoryViewModels);

        var query = new GetBlogCategoriesQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(blogCategoryViewModels);
        await _sharedFixture.UnitOfWork.BlogCategoryRepository.Received(1).GetAllAsync();
        _sharedFixture.Mapper.Received(1).Map<List<BlogCategoryViewModel>>(blogCategories);
    }
}
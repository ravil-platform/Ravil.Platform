using System.Linq.Expressions;
using Application.Features.Blog.Queries.GetBlogCategoriesByParentId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Common.Exceptions;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Blog;

namespace Application.UnitTest.Features.Blog.Queries.GetBlogCategoriesByParentId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetBlogCategoriesByParentIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetBlogCategoriesByParentIdQueryHandler _handler;

    public GetBlogCategoriesByParentIdQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetBlogCategoriesByParentIdQueryHandler(_sharedFixture.UnitOfWork, _sharedFixture.Mapper);
    }

    [Fact]
    public async Task Should_ThrowNotFoundException_WhenNoCategoriesFoundForParentId()
    {
        // Arrange
        var parentId = 123;
        _sharedFixture.UnitOfWork.BlogCategoryRepository
            .GetAllAsync(p => p.ParentId == parentId)
            .Returns(Task.FromResult<IList<Domain.Entities.Blog.BlogCategory>>(new List<Domain.Entities.Blog.BlogCategory>()));

        var query = new GetBlogCategoriesByParentIdQuery { ParentId = parentId };

        // Act & Assert
        await FluentActions.Invoking(() => _handler.Handle(query, CancellationToken.None))
            .Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Should_ReturnMappedCategories_WhenCategoriesExistForParentId()
    {
        // Arrange
        var parentId = 123;
        var blogCategories = new List<Domain.Entities.Blog.BlogCategory>
        {
            new Domain.Entities.Blog.BlogCategory { ParentId = parentId, Title = "Cat1" },
            new Domain.Entities.Blog.BlogCategory { ParentId = parentId, Title = "Cat2" }
        };

        var blogCategoryViewModels = new List<BlogCategoryViewModel>
        {
            new BlogCategoryViewModel { ParentId = parentId, Title = "Cat1" },
            new BlogCategoryViewModel {ParentId = parentId,  Title = "Cat2" }
        };

        Expression<Func<Domain.Entities.Blog.BlogCategory, bool>> filter = p => p.ParentId == parentId;
        _sharedFixture.UnitOfWork.BlogCategoryRepository
            .GetAllAsync(filter)
            .Returns(Task.FromResult<ICollection<Domain.Entities.Blog.BlogCategory>>(blogCategories));


        _sharedFixture.Mapper.Map<List<BlogCategoryViewModel>>(blogCategories)
            .Returns(blogCategoryViewModels);

        var query = new GetBlogCategoriesByParentIdQuery { ParentId = parentId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(blogCategoryViewModels);

        await _sharedFixture.UnitOfWork.BlogCategoryRepository.Received(1)
            .GetAllAsync(filter);

        _sharedFixture.Mapper.Received(1).Map<List<BlogCategoryViewModel>>(blogCategories);
    }
}
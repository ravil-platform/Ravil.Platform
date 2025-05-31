using Application.Features.Category.Queries.GetChildCategories;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetChildCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GetChildCategoryQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetChildCategoryQueryHandler _handler;

    public GetChildCategoryQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetChildCategoryQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
    }

    [Fact]
    public async Task Should_ReturnCategories_WhenNodeLevelIsNot3()
    {
        // Arrange
        var query = new GetChildCategoryQuery { NodeLevel = 2, ParentId = 5 };
        var categories = new List<Domain.Entities.Category.Category>
        {
            new() { Id = 1, Name = "Cat 1" },
            new() { Id = 2, Name = "Cat 2" }
        };

        _sharedFixture.UnitOfWork.CategoryRepository
            .GetChildCategories(query.NodeLevel, query.ParentId)
            .Returns(categories);

        _sharedFixture.Mapper
            .Map<List<CategoryViewModel>>(categories)
            .Returns(new List<CategoryViewModel>
            {
                new() { Id = 1, Name = "Cat 1" },
                new() { Id = 2, Name = "Cat 2" }
            });

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value[0].Name.Should().Be("Cat 1");
    }

    [Fact]
    public async Task Should_Call_SetTargetRoutes_WhenNodeLevelIs3()
    {
        // Arrange
        var query = new GetChildCategoryQuery { NodeLevel = 3, ParentId = 7 };
        var categories = new List<Domain.Entities.Category.Category>
        {
            new() { Id = 3, Name = "Cat 3" },
            new() { Id = 4, Name = "Cat 4" }
        };

        _sharedFixture.UnitOfWork.CategoryRepository
            .GetChildCategories(query.NodeLevel, query.ParentId)
            .Returns(categories);

        _sharedFixture.UnitOfWork.CategoryRepository
            .SetTargetRoutes(categories)
            .Returns(categories); // همون لیست رو فرض می‌گیریم برمی‌گردونه

        _sharedFixture.Mapper
            .Map<List<CategoryViewModel>>(categories)
            .Returns(new List<CategoryViewModel>
            {
                new() { Id = 3, Name = "Cat 3" },
                new() { Id = 4, Name = "Cat 4" }
            });

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        await _sharedFixture.UnitOfWork.CategoryRepository.Received(1).SetTargetRoutes(categories);
    }
}
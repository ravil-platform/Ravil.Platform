using System.Linq.Expressions;
using Application.Features.Category.Queries.GetAllByParentId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetAllByCategoryService;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllCategoryByParentIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllCategoryByParentIdQueryHandler _handler;

    public GetAllCategoryByParentIdQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllCategoryByParentIdQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
    }

    [Fact]
    public async Task Should_ReturnMappedResult_When_CategoriesExist()
    {
        // Arrange
        var categories = new List<Domain.Entities.Category.Category>
        {
            new() { Id = 1, Name = "Backend" },
            new() { Id = 2, Name = "Frontend" }
        };

        var expectedVm = new List<CategoryViewModel>
        {
            new() { Id = 1, Name = "Backend" },
            new() { Id = 2, Name = "Frontend" }
        };

        _sharedFixture.UnitOfWork.CategoryRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
            .Returns(categories);

        _sharedFixture.Mapper
            .Map<List<CategoryViewModel>>(categories)
            .Returns(expectedVm);

        var request = new GetAllCategoriesByParentIdQuery()
        {
            ParentId = 1
        };

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(expectedVm);
    }

    [Fact]
    public async Task Should_ReturnFailResult_When_NoCategoriesFound()
    {
        // Arrange
        _sharedFixture.UnitOfWork.CategoryRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
            .Returns(new List<Domain.Entities.Category.Category>());

        var request = new GetAllCategoriesByParentIdQuery()
        {
            ParentId = 999
        };

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }
}
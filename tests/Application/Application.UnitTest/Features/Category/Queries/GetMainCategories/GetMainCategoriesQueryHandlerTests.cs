using Application.Features.Category.Queries.GetMainCategories;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetMainCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GetMainCategoriesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetMainCategoriesQueryHandler _handler;

    public GetMainCategoriesQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetMainCategoriesQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
    }

    [Fact]
    public async Task Should_Return_MainCategories_Successfully()
    {
        // Arrange
        var mainCategories = new List<Domain.Entities.Category.Category>
        {
            new() { Id = 1, Name = "Main Cat 1" },
            new() { Id = 2, Name = "Main Cat 2" }
        };

        _sharedFixture.UnitOfWork.CategoryRepository
            .GetMainCategories()
            .Returns(mainCategories);

        _sharedFixture.Mapper
            .Map<List<MainCategories>>(mainCategories)
            .Returns(new List<MainCategories>
            {
                new() { Id = 1, Name = "Main Cat 1" },
                new() { Id = 2, Name = "Main Cat 2" }
            });

        var query = new GetMainCategoriesQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value[0].Name.Should().Be("Main Cat 1");
    }
}
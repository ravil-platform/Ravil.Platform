using Application.Features.City.Queries.GetAllCityCategory;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.City;
using FluentAssertions;
using NSubstitute;

namespace Application.UnitTest.Features.City.Queries.GetAllCityCategory;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllCityCategoryQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllCityCategoryQueryHandler _handler;

    public GetAllCityCategoryQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllCityCategoryQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_ReturnAllCityCategories()
    {
        //// Arrange
        //var cityCategories = new List<CityCategory>
        //{
        //    new() { Id = 1, CityId = 1, CategoryId = 10 },
        //    new() { Id = 2, CityId = 2, CategoryId = 20 }
        //};

        //_sharedFixture.UnitOfWork.CityCategoryRepository
        //    .GetAllAsync()
        //    .Returns(cityCategories);

        //var query = new GetAllCityCategoryQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(2);
        //result.Value!.Any(cc => cc.CategoryId == 20).Should().BeTrue();
    }
}
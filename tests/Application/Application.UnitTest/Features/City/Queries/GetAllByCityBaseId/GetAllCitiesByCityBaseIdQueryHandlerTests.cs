using System.Linq.Expressions;
using Application.Features.City.Queries.GetAllByCityBaseId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.City;
using FluentAssertions;

namespace Application.UnitTest.Features.City.Queries.GetAllByCityBaseId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllCitiesByCityBaseIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllCitiesByCityBaseIdQueryHandler _handler;

    public GetAllCitiesByCityBaseIdQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllCitiesByCityBaseIdQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_ReturnCities_ByCityBaseId()
    {
        //// Arrange
        //var cityBaseId = 1;

        //var cities = new List<Domain.Entities.City.City>
        //{
        //    new() { Id = 1, Subtitle = "شیراز", CityBaseId = cityBaseId, CityBase = new CityBase() },
        //    new() { Id = 2, Subtitle = "بوشهر", CityBaseId = cityBaseId, CityBase = new CityBase() }
        //};

        ////_sharedFixture.UnitOfWork.CityRepository
        ////    .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.City.City, bool>>>(), Arg.Any<string>())
        ////    .Returns(cities);

        //var query = new GetAllCitiesByCityBaseIdQuery { CityBaseId = cityBaseId };

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(2);
        //result.Value!.Any(c => c.Name == "شیراز").Should().BeTrue();
    }
}
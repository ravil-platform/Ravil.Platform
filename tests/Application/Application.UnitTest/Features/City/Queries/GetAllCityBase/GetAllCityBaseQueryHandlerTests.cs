using Application.Features.City.Queries.GetAllCityBase;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.City;
using FluentAssertions;
using NSubstitute;

namespace Application.UnitTest.Features.City.Queries.GetAllCityBase;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllCityBaseQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllCityBaseQueryHandler _handler;

    public GetAllCityBaseQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllCityBaseQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_ReturnAllCityBases()
    {
        //// Arrange
        //var cityBases = new List<CityBase>
        //{
        //    new() { Id = 1, Name = "جنوب کشور" },
        //    new() { Id = 2, Name = "شمال کشور" }
        //};

        //_sharedFixture.UnitOfWork.CityBaseRepository
        //    .GetAllAsync()
        //    .Returns(cityBases);

        //var query = new GetAllCityBaseQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(2);
        //result.Value!.Any(c => c.Name == "شمال کشور").Should().BeTrue();
    }
}
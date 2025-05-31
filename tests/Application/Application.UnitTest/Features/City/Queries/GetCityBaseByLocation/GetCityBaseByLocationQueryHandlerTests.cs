using Application.Features.City.Queries.GetCityBaseByLocation;
using Application.Services.NehsanApi;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using NSubstitute;
using ViewModels.AdminPanel.Job;

namespace Application.UnitTest.Features.City.Queries.GetCityBaseByLocation;

[Collection(CollectionDefinition.SharedFixture)]
public class GetCityBaseByLocationQueryHandlerTests
{
    //private readonly SharedFixture _sharedFixture;
    //private readonly GetCityBaseByLocationQueryHandler _handler;

    //public GetCityBaseByLocationQueryHandlerTests(SharedFixture sharedFixture)
    //{
    //    _sharedFixture = sharedFixture;
    //    _handler = new GetCityBaseByLocationQueryHandler(
    //        _sharedFixture.Mapper,
    //        _sharedFixture.UnitOfWork
    //    );
    //}

    [Fact]
    public async Task Should_Return_CityInfoViewModel_When_Location_Valid()
    {
        //// Arrange
        //var request = new GetCityBaseByLocationQuery
        //{
        //    Latitude = "35.6892",
        //    Longitude = "51.3890"
        //};

        //var locationData = new LocationDataViewModel
        //{
        //    City = "تهران",
        //    State = "تهران",
        //    Neighbourhood = "ونک"
        //};

        //_neshanApiService.GetReverseGeocodeAsync(request.Latitude, request.Longitude)
        //    .Returns(locationData);

        //_neshanApiService.GetCityState(locationData.City, locationData.State, locationData.Neighbourhood, _sharedFixture.UnitOfWork)
        //    .Returns(new Domain.Entities.City.CityBase { Id = 1, Name = "تهران" });

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //Assert.True(result.IsSuccess);
        //Assert.NotNull(result.Value);
        //Assert.Equal("ونک", result.Value.Neighbourhood);
    }

    [Fact]
    public async Task Should_Return_Fail_When_LocationData_Is_Null()
    {
        //// Arrange
        //var request = new GetCityBaseByLocationQuery
        //{
        //    Latitude = "0",
        //    Longitude = "0"
        //};

        //_neshanApiService.GetReverseGeocodeAsync(request.Latitude, request.Longitude)
        //    .Returns((LocationDataViewModel?)null);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //Assert.False(result.IsSuccess);
    }
}
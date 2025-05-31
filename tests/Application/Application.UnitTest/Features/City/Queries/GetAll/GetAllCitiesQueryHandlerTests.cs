using Application.Features.City.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Constants.Caching;

namespace Application.UnitTest.Features.City.Queries.GetAll;

[Collection(CollectionDefinition.SharedDistributedCacheFixture)]
public class GetAllCitiesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly DistributedCacheFixture _cacheFixture;
    private readonly GetAllCitiesQueryHandler _handler;

    public GetAllCitiesQueryHandlerTests(SharedFixture sharedFixture, DistributedCacheFixture cacheFixture)
    {
        _sharedFixture = sharedFixture;
        _cacheFixture = cacheFixture;

        _handler = new GetAllCitiesQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _cacheFixture.DistributedCache);
    }

    [Fact]
    public async Task Should_ReturnCities_When_CacheIsEmpty()
    {
        //// Arrange
        //var cacheKey = CacheKeys.GetAllCitiesQuery();

        //await _cacheFixture.DistributedCache
        //    .GetAsync(cacheKey, Arg.Any<CancellationToken>())
        //    .Returns((byte[])null!);

        //var cities = new List<Domain.Entities.City.City>
        //{
        //    new() { Id = 1, Name = "تهران", Subtitle = "پایتخت", Route = "tehran", Picture = "1.jpg", CityBaseId = 1, CityBase = new CityBase() },
        //    new() { Id = 2, Name = "اصفهان", Subtitle = "نصف جهان", Route = "isfahan", Picture = "2.jpg", CityBaseId = 2, CityBase = new CityBase() }
        //};

        //_sharedFixture.UnitOfWork.CityRepository
        //    .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.City.City, bool>>>(), Arg.Any<string>())
        //    .Returns(cities);

        //// Act
        //var result = await _handler.Handle(new GetAllCitiesQuery(), CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(2);
        //result.Value!.First().Name.Should().Be("تهران");
    }
}
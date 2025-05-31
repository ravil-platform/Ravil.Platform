using Application.Features.Category.Queries.GetRelatedRegion;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Category;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace Application.UnitTest.Features.Category.Queries.GetRelatedRegion;

[Collection(CollectionDefinition.SharedFixture)]
public class GetRelatedRegionQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetRelatedRegionQueryHandler _handler;

    public GetRelatedRegionQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetRelatedRegionQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
    }

    [Fact]
    public async Task Should_Return_RelatedCategorySeo_ByCityId()
    {
        // Arrange
        var cityId = 11;
        var relatedData = new List<RelatedCategorySeo>
        {
            new() { Id = 1, CurrentCityId = cityId},
            new() { Id = 2, CurrentCityId = cityId}
        };

        var mockQueryable = relatedData.AsQueryable().BuildMockDbSet();

        _sharedFixture.UnitOfWork.RelatedCategorySeoRepository
            .TableNoTracking
            .Returns(mockQueryable);

        var query = new GetRelatedRegionQuery { CurrentCityId = cityId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value[0].CurrentCityId.Should().Be(cityId);
    }
}
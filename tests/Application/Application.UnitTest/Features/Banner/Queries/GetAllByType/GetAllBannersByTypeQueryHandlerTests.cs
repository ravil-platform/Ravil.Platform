using System.Linq.Expressions;
using Application.Features.Banner.GetAllByType;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Common.Exceptions;
using Enums;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Banner;

namespace Application.UnitTest.Features.Banner.Queries.GetAllByType;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllBannersByTypeQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllBannersByTypeQueryHandler _handler;

    public GetAllBannersByTypeQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllBannersByTypeQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);

        _sharedFixture.UnitOfWork.BannerRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedBannerViewModelListByType_WhenBannersExist()
    {
        // Arrange
        var bannerType = BannerType.Blog;

        var bannersFromRepo = new List<Domain.Entities.Banner.Banner>
        {
            new Domain.Entities.Banner.Banner { Title = "Banner1", BannerType = bannerType },
            new Domain.Entities.Banner.Banner { Title = "Banner2", BannerType = bannerType }
        };

        var bannersViewModel = new List<BannerViewModel>
        {
            new BannerViewModel { Title = "Banner1", BannerType = bannerType },
            new BannerViewModel { Title = "Banner2", BannerType = bannerType }
        };

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>())
            .Returns(Task.FromResult((ICollection<Domain.Entities.Banner.Banner>)bannersFromRepo));

        _sharedFixture.Mapper.Map<List<BannerViewModel>>(bannersFromRepo).Returns(bannersViewModel);

        var query = new GetAllBannersByTypeQuery { BannerType = bannerType };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(bannersViewModel);

        await _sharedFixture.UnitOfWork.BannerRepository.Received(1)
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>());

        _sharedFixture.Mapper.Received(1).Map<List<BannerViewModel>>(bannersFromRepo);
    }

    [Fact]
    public async Task Should_ThrowNotFoundException_WhenNoBannersFound()
    {
        // Arrange
        var bannerType = BannerType.Blog;

        var emptyList = new List<Domain.Entities.Banner.Banner>();

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>())
            .Returns(Task.FromResult((ICollection<Domain.Entities.Banner.Banner>)emptyList));

        var query = new GetAllBannersByTypeQuery { BannerType = bannerType };

        // Act & Assert
        await FluentActions.Invoking(() => _handler.Handle(query, CancellationToken.None))
            .Should().ThrowAsync<NotFoundException>();

        await _sharedFixture.UnitOfWork.BannerRepository.Received(1)
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>());

        _sharedFixture.Mapper.DidNotReceive().Map<List<BannerViewModel>>(Arg.Any<List<Domain.Entities.Banner.Banner>>());
    }
}
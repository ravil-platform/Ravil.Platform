using Application.Features.Banner.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Banner;

namespace Application.UnitTest.Features.Banner.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllBannersQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllBannersQueryHandler _handler;

    public GetAllBannersQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllBannersQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.BannerRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedBannerViewModelList_WhenCalled()
    {
        // Arrange
        var bannersFromRepo = new List<Domain.Entities.Banner.Banner>
            {
                new Domain.Entities.Banner.Banner { Title = "Banner1", Description = "Desc1" },
                new Domain.Entities.Banner.Banner { Title = "Banner2", Description = "Desc2" }
            };

        var bannersViewModel = new List<BannerViewModel>
            {
                new BannerViewModel { Title = "Banner1", Description = "Desc1" },
                new BannerViewModel { Title = "Banner2", Description = "Desc2" }
            };

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync()!
            .Returns(Task.FromResult((ICollection<Domain.Entities.Banner.Banner>)bannersFromRepo));

        _sharedFixture.Mapper.Map<List<BannerViewModel>>(bannersFromRepo).Returns(bannersViewModel);

        var query = new GetAllBannersQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(bannersViewModel);
        await _sharedFixture.UnitOfWork.BannerRepository.Received(1).GetAllAsync();
        _sharedFixture.Mapper.Received(1).Map<List<BannerViewModel>>(bannersFromRepo);
    }


    [Fact]
    public async Task Should_ReturnEmptyList_WhenRepositoryReturnsEmpty()
    {
        // Arrange
        var emptyBanners = new List<Domain.Entities.Banner.Banner>();
        var emptyViewModelList = new List<BannerViewModel>();

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync()!
            .Returns(Task.FromResult((ICollection<Domain.Entities.Banner.Banner>)emptyBanners));

        _sharedFixture.Mapper.Map<List<BannerViewModel>>(emptyBanners).Returns(emptyViewModelList);

        var query = new GetAllBannersQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEmpty();

        await _sharedFixture.UnitOfWork.BannerRepository.Received(1).GetAllAsync();

        _sharedFixture.Mapper.Received(1).Map<List<BannerViewModel>>(emptyBanners);
    }
}


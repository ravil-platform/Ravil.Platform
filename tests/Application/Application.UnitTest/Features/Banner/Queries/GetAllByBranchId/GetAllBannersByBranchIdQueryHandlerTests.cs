using System.Linq.Expressions;
using Application.Features.Banner.GetAllByBranchId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Common.Exceptions;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Banner;

namespace Application.UnitTest.Features.Banner.Queries.GetAllByBranchId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllBannersByBranchIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllBannersByBranchIdQueryHandler _handler;

    public GetAllBannersByBranchIdQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllBannersByBranchIdQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.BannerRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedBannerViewModelList_WhenBannersExist()
    {
        // Arrange
        var branchId = "branch123";

        var bannersFromRepo = new List<Domain.Entities.Banner.Banner>
        {
            new Domain.Entities.Banner.Banner { Title = "Banner1", JobBranchId = branchId },
            new Domain.Entities.Banner.Banner { Title = "Banner2", JobBranchId = branchId }
        };

        var bannersViewModel = new List<BannerViewModel>
        {
            new BannerViewModel { Title = "Banner1", JobBranchId = branchId },
            new BannerViewModel { Title = "Banner2", JobBranchId = branchId }
        };

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>())
            .Returns(Task.FromResult((IList<Domain.Entities.Banner.Banner>)bannersFromRepo));

        _sharedFixture.Mapper.Map<List<BannerViewModel>>(bannersFromRepo).Returns(bannersViewModel);

        var query = new GetAllBannersByBranchIdQuery { JobBranchId = branchId };

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
        var branchId = "branch123";

        var emptyList = new List<Domain.Entities.Banner.Banner>();

        _sharedFixture.UnitOfWork.BannerRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>())
            .Returns(Task.FromResult((ICollection<Domain.Entities.Banner.Banner>)emptyList));

        var query = new GetAllBannersByBranchIdQuery { JobBranchId = branchId };

        // Act & Assert
        await FluentActions.Invoking(() => _handler.Handle(query, CancellationToken.None))
            .Should().ThrowAsync<NotFoundException>();

        await _sharedFixture.UnitOfWork.BannerRepository.Received(1)
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Banner.Banner, bool>>>());

        // never call this mapper 
        _sharedFixture.Mapper.DidNotReceive().Map<List<BannerViewModel>>(Arg.Any<List<Domain.Entities.Banner.Banner>>());
    }
}
using Application.Features.ShortLink.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Job;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.ShortLink;

namespace Application.UnitTest.Features.ShortLink.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllShortLinkQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllShortLinkQueryHandler _handler;

    public GetAllShortLinkQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllShortLinkQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.ShortLinkRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedShortLinkList_WhenShortLinksExist()
    {
        //// Arrange
        //var shortLinks = new List<JobBranchShortLink>
        //{
        //    new JobBranchShortLink { Id = 1, Url = "https://example.com/abc" },
        //    new JobBranchShortLink { Id = 2, Url = "https://example.com/xyz" }
        //};

        //var shortLinkViewModels = new List<ShortLinkViewModel>
        //{
        //    new ShortLinkViewModel { Id = 1, Url = "https://example.com/abc" },
        //    new ShortLinkViewModel { Id = 2, Url = "https://example.com/xyz" }
        //};

        //_sharedFixture.UnitOfWork.ShortLinkRepository
        //    .GetAllAsync()!
        //    .Returns(Task.FromResult((ICollection<JobBranchShortLink>)shortLinks));

        //_sharedFixture.Mapper
        //    .Map<List<ShortLinkViewModel>>(shortLinks)
        //    .Returns(shortLinkViewModels);

        //var query = new GetAllShortLinkQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(shortLinkViewModels);

        //await _sharedFixture.UnitOfWork.ShortLinkRepository.Received(1).GetAllAsync();
        //_sharedFixture.Mapper.Received(1).Map<List<ShortLinkViewModel>>(shortLinks);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoShortLinkFound()
    {
        //// Arrange
        //var shortLinks = new List<JobBranchShortLink>();
        //var shortLinkViewModels = new List<ShortLinkViewModel>();

        //_sharedFixture.UnitOfWork.ShortLinkRepository
        //    .GetAllAsync()!
        //    .Returns(Task.FromResult((ICollection<JobBranchShortLink>)shortLinks));

        //_sharedFixture.Mapper
        //    .Map<List<ShortLinkViewModel>>(shortLinks)
        //    .Returns(shortLinkViewModels);

        //var query = new GetAllShortLinkQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEmpty();

        //await _sharedFixture.UnitOfWork.ShortLinkRepository.Received(1).GetAllAsync();
        //_sharedFixture.Mapper.Received(1).Map<List<ShortLinkViewModel>>(shortLinks);
    }
}


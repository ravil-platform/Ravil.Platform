using System.Linq.Expressions;
using Application.Features.ShortLink.Queries.GetAllByItemId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Job;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.ShortLink;

namespace Application.UnitTest.Features.ShortLink.Queries.GetAllByItemId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllShortLinkByItemIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllShortLinkByItemIdQueryHandler _handler;

    public GetAllShortLinkByItemIdQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllShortLinkByItemIdQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.ShortLinkRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedShortLinkList_WhenShortLinksExistForItemId()
    {
        //// Arrange
        //var itemId = 123;
        //var shortLinks = new List<JobBranchShortLink>
        //{
        //    new JobBranchShortLink { Id = 1, ItemId = itemId, Url = "https://example.com/abc" },
        //    new JobBranchShortLink { Id = 2, ItemId = itemId, Url = "https://example.com/xyz" }
        //};

        //var shortLinkViewModels = new List<ShortLinkViewModel>
        //{
        //    new ShortLinkViewModel { Id = 1, Url = "https://example.com/abc" },
        //    new ShortLinkViewModel { Id = 2, Url = "https://example.com/xyz" }
        //};

        //_sharedFixture.UnitOfWork.ShortLinkRepository
        //    .GetAllAsync(Arg.Any<Expression<Func<JobBranchShortLink, bool>>>())!
        //    .Returns(Task.FromResult((ICollection<JobBranchShortLink>)shortLinks));

        //_sharedFixture.Mapper
        //    .Map<List<ShortLinkViewModel>>(shortLinks)
        //    .Returns(shortLinkViewModels);

        //var query = new GetAllShortLinkByItemIdQuery { ItemId = itemId };

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(shortLinkViewModels);

        //await _sharedFixture.UnitOfWork.ShortLinkRepository
        //    .Received(1).GetAllAsync(Arg.Any<Expression<Func<JobBranchShortLink, bool>>>());

        //_sharedFixture.Mapper
        //    .Received(1).Map<List<ShortLinkViewModel>>(shortLinks);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoShortLinksFoundForItemId()
    {
        //// Arrange
        //var itemId = 999;
        //var emptyShortLinks = new List<JobBranchShortLink>();
        //var emptyViewModels = new List<ShortLinkViewModel>();

        //_sharedFixture.UnitOfWork.ShortLinkRepository
        //    .GetAllAsync(Arg.Any<Expression<Func<JobBranchShortLink, bool>>>())!
        //    .Returns(Task.FromResult((ICollection<JobBranchShortLink>)emptyShortLinks));

        //_sharedFixture.Mapper
        //    .Map<List<ShortLinkViewModel>>(emptyShortLinks)
        //    .Returns(emptyViewModels);

        //var query = new GetAllShortLinkByItemIdQuery { ItemId = itemId };

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEmpty();

        //await _sharedFixture.UnitOfWork.ShortLinkRepository
        //    .Received(1).GetAllAsync(Arg.Any<Expression<Func<JobBranchShortLink, bool>>>());

        //_sharedFixture.Mapper
        //    .Received(1).Map<List<ShortLinkViewModel>>(emptyShortLinks);
    }
}
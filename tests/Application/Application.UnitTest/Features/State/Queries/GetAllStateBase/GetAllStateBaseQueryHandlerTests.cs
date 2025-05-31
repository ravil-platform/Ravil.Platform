using Application.Features.State.Queries.GetAllStateBase;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.State;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.State;

namespace Application.UnitTest.Features.State.Queries.GetAllStateBase;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllStateBaseQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllStateBaseQueryHandler _handler;

    public GetAllStateBaseQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllStateBaseQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.StateBaseRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedStateBaseList_WhenDataExists()
    {
        // Arrange
        var stateBases = new List<StateBase>
        {
            new StateBase { Id = 1, Name = "Region A" },
            new StateBase { Id = 2, Name = "Region B" }
        };

        var mappedViewModels = new List<StateBaseViewModel>
        {
            new StateBaseViewModel { Id = 1, Name = "Region A" },
            new StateBaseViewModel { Id = 2, Name = "Region B" }
        };

        _sharedFixture.UnitOfWork.StateBaseRepository
            .GetAllAsync()
            .Returns(Task.FromResult((IList<StateBase>)stateBases));

        _sharedFixture.Mapper
            .Map<List<StateBaseViewModel>>(stateBases)
            .Returns(mappedViewModels);

        var query = new GetAllStateBaseQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(mappedViewModels);

        await _sharedFixture.UnitOfWork.StateBaseRepository.Received(1).GetAllAsync();
        _sharedFixture.Mapper.Received(1).Map<List<StateBaseViewModel>>(stateBases);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoStateBaseExists()
    {
        // Arrange
        var stateBases = new List<StateBase>();
        var mappedViewModels = new List<StateBaseViewModel>();

        _sharedFixture.UnitOfWork.StateBaseRepository
            .GetAllAsync()
            .Returns(Task.FromResult((IList<StateBase>)stateBases));

        _sharedFixture.Mapper
            .Map<List<StateBaseViewModel>>(stateBases)
            .Returns(mappedViewModels);

        var query = new GetAllStateBaseQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEmpty();

        await _sharedFixture.UnitOfWork.StateBaseRepository.Received(1).GetAllAsync();
        _sharedFixture.Mapper.Received(1).Map<List<StateBaseViewModel>>(stateBases);
    }
}
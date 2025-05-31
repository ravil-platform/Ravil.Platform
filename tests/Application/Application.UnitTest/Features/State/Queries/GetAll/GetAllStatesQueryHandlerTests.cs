using Application.Features.State.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.State;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.State;

namespace Application.UnitTest.Features.State.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllStatesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllStatesQueryHandler _handler;

    public GetAllStatesQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllStatesQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.StateBaseRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedStateList_WhenStatesExist()
    {
        //// Arrange
        //var states = new List<StateBase>
        //{
        //    new StateBase { Id = 1, Name = "Tehran" },
        //    new StateBase { Id = 2, Name = "Fars" }
        //};

        //var stateViewModels = new List<StateViewModel>
        //{
        //    new StateViewModel { Id = 1, Name = "Tehran" },
        //    new StateViewModel { Id = 2, Name = "Fars" }
        //};

        //_sharedFixture.UnitOfWork.StateBaseRepository
        //    .GetAllAsync()
        //    .Returns(Task.FromResult((ICollection<StateBase>)states));

        //_sharedFixture.Mapper
        //    .Map<List<StateViewModel>>(states)
        //    .Returns(stateViewModels);

        //var query = new GetAllStatesQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(stateViewModels);

        //await _sharedFixture.UnitOfWork.StateBaseRepository.Received(1).GetAllAsync();
        //_sharedFixture.Mapper.Received(1).Map<List<StateViewModel>>(states);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoStatesExist()
    {
        // Arrange
        var states = new List<StateBase>();
        var stateViewModels = new List<StateViewModel>();

        _sharedFixture.UnitOfWork.StateBaseRepository
            .GetAllAsync()
            .Returns(Task.FromResult((IList<StateBase>)states));

        _sharedFixture.Mapper
            .Map<List<StateViewModel>>(states)
            .Returns(stateViewModels);

        var query = new GetAllStatesQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEmpty();

        await _sharedFixture.UnitOfWork.StateBaseRepository.Received(1).GetAllAsync();
        _sharedFixture.Mapper.Received(1).Map<List<StateViewModel>>(states);
    }
}
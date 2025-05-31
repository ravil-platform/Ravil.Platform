using System.Linq.Expressions;
using Application.Features.State.Queries.GetAllByStateBaseId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.State;

namespace Application.UnitTest.Features.State.Queries.GetAllByStateBaseId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllStatesByStateBaseIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllStatesByStateBaseIdQueryHandler _handler;

    public GetAllStatesByStateBaseIdQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllStatesByStateBaseIdQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.StateRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedStates_WhenStatesExistForGivenBaseId()
    {
        //// Arrange
        //var stateBaseId = 10;

        //var states = new List<Domain.Entities.State.State>
        //{
        //    new Domain.Entities.State.State { Id = 1, Name = "Tehran", StateBaseId = stateBaseId },
        //    new Domain.Entities.State.State { Id = 2, Name = "Mashhad", StateBaseId = stateBaseId }
        //};

        //var mappedStates = new List<StateViewModel>
        //{
        //    new StateViewModel { Id = 1, Name = "Tehran" },
        //    new StateViewModel { Id = 2, Name = "Mashhad" }
        //};

        //_sharedFixture.UnitOfWork.StateRepository
        //    .GetAllAsync(s => s.StateBaseId == stateBaseId)
        //    .Returns(Task.FromResult((ICollection<State>)states));

        //_sharedFixture.Mapper
        //    .Map<List<StateViewModel>>(states)
        //    .Returns(mappedStates);

        //var query = new GetAllStatesByStateBaseIdQuery { StateBaseId = stateBaseId };

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(mappedStates);

        //await _sharedFixture.UnitOfWork.StateRepository.Received(1).GetAllAsync(Arg.Any<Expression<Func<State, bool>>>());
        //_sharedFixture.Mapper.Received(1).Map<List<StateViewModel>>(states);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoStatesExistForGivenBaseId()
    {
        //// Arrange
        //var stateBaseId = 99;
        //var states = new List<State>();
        //var mappedStates = new List<StateViewModel>();

        //_sharedFixture.UnitOfWork.StateRepository
        //    .GetAllAsync(s => s.StateBaseId == stateBaseId)
        //    .Returns(Task.FromResult((ICollection<State>)states));

        //_sharedFixture.Mapper
        //    .Map<List<StateViewModel>>(states)
        //    .Returns(mappedStates);

        //var query = new GetAllStatesByStateBaseIdQuery { StateBaseId = stateBaseId };

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEmpty();

        //await _sharedFixture.UnitOfWork.StateRepository.Received(1).GetAllAsync(Arg.Any<Expression<Func<State, bool>>>());
        //_sharedFixture.Mapper.Received(1).Map<List<StateViewModel>>(states);
    }
}
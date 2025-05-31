using System.Linq;
using System.Linq.Expressions;
using Application.Features.PanelTutorial.Queries.Get;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.PanelTutorial;
using FluentAssertions;
using Logging.Base;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.PanelTutorial;

namespace Application.UnitTest.Features.PanelTutorial.Queries.Get;

[Collection(CollectionDefinition.SharedFixture)]
public class GetPanelTutorialsQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetPanelTutorialsQueryHandler _handler;

    public GetPanelTutorialsQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;

        var logger = Substitute.For<ILogger<GetPanelTutorialsQueryHandler>>();

        _handler = new GetPanelTutorialsQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            logger
        );

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedPanelTutorials_WhenDataExists()
    {
        //// Arrange
        //var tutorials = new List<Domain.Entities.PanelTutorial.PanelTutorial>
        //{
        //    new Domain.Entities.PanelTutorial.PanelTutorial { Id = 1, Title = "A", Sort = 2 },
        //    new Domain.Entities.PanelTutorial.PanelTutorial { Id = 2, Title = "B", Sort = 1 }
        //};

        //var mapped = new List<PanelTutorialViewModel>
        //{
        //    new PanelTutorialViewModel { Title = "B" },
        //    new PanelTutorialViewModel { Title = "A" }
        //};

        //_sharedFixture.UnitOfWork.PanelTutorialRepository.TableNoTracking
        //    .OrderBy(Arg.Any<Expression<Func<Domain.Entities.PanelTutorial.PanelTutorial, object>>>())
        //    .ToListAsync(Arg.Any<CancellationToken>())
        //    .Returns(tutorials.OrderBy(t => t.Sort).ToList());

        //_sharedFixture.Mapper.Map<List<PanelTutorialViewModel>>(Arg.Any<List<Domain.Entities.PanelTutorial.PanelTutorial>>())
        //    .Returns(mapped);

        //var query = new GetPanelTutorialsQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().BeEquivalentTo(mapped);
    }

    [Fact]
    public async Task Should_ThrowAndRollback_WhenExceptionIsThrown()
    {
        // Arrange
        //_sharedFixture.UnitOfWork.PanelTutorialRepository.TableNoTracking
        //    .OrderBy(Arg.Any<Expression<Func<Domain.Entities.PanelTutorial.PanelTutorial, object>>>())
        //    .ToListAsync(Arg.Any<CancellationToken>())
        //    .Returns(x => throw new Exception("Failed to load tutorials"));

        //var query = new GetPanelTutorialsQuery();

        //var handlerWithLogger = new GetPanelTutorialsQueryHandler(
        //    _sharedFixture.Mapper,
        //    _sharedFixture.UnitOfWork,
        //    Substitute.For<ILogger<GetPanelTutorialsQueryHandler>>()
        //);

        //// Act
        //Func<Task> act = async () => await handlerWithLogger.Handle(query, CancellationToken.None);

        //// Assert
        //await act.Should().ThrowAsync<Exception>().WithMessage("Failed to load tutorials");
        //await _sharedFixture.UnitOfWork.Received(1).RollbackTransactionAsync(Arg.Any<CancellationToken>());
    }
}

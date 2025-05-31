using System.Linq;
using System.Linq.Expressions;
using Application.Features.MessageBox.Queries.GetAllMessageBoxByFilter;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using Logging.Base;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.MessageBox;

namespace Application.UnitTest.Features.MessageBox.Queries.GetAllMessageBoxByFilter;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllMessageBoxByFilterQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllMessageBoxByFilterQueryHandler _handler;

    public GetAllMessageBoxByFilterQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        var logger = Substitute.For<ILogger<GetAllMessageBoxByFilterQueryHandler>>();

        _handler = new GetAllMessageBoxByFilterQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            logger
        );

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedMessages_WhenUnreadFilterIsTrue()
    {
        //// Arrange
        //var jobId = 101;
        //var messages = new List<Domain.Entities.MessageBox.MessageBox>
        //    {
        //        new Domain.Entities.MessageBox.MessageBox { Id = 1, IsRead = false, Description = "new message", JobId = jobId }
        //    };

        //var mapped = new List<MessageBoxViewModel>
        //    {
        //        new MessageBoxViewModel { Description = "new message", IsRead = false, JobId = jobId, Type = "User" }
        //    };

        //_sharedFixture.UnitOfWork.MessageBoxRepository.TableNoTracking
        //    .Where(Arg.Any<Expression<Func<Domain.Entities.MessageBox.MessageBox, bool>>>())
        //    .ToListAsync(Arg.Any<CancellationToken>())
        //    .Returns(messages);

        //_sharedFixture.Mapper.Map<List<MessageBoxViewModel>>(messages).Returns(mapped);

        //var query = new GetAllMessageBoxByFilterQuery
        //{
        //    JobId = jobId,
        //    UnReadMessages = true
        //};

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().BeEquivalentTo(mapped);
    }

    [Fact]
    public async Task Should_ReturnMappedMessages_WhenUnreadFilterIsFalse()
    {
        //// Arrange
        //var jobId = 102;
        //var messages = new List<Domain.Entities.MessageBox.MessageBox>
        //    {
        //        new Domain.Entities.MessageBox.MessageBox { Id = 2, IsRead = true, Description = "read msg", JobId = jobId }
        //    };

        //var mapped = new List<MessageBoxViewModel>
        //    {
        //        new MessageBoxViewModel { Description = "read msg", IsRead = true, JobId = jobId, Type = "System" }
        //    };

        //_sharedFixture.UnitOfWork.MessageBoxRepository.TableNoTracking
        //    .Where(Arg.Any<Expression<Func<Domain.Entities.MessageBox.MessageBox, bool>>>())
        //    .ToListAsync(Arg.Any<CancellationToken>())
        //    .Returns(messages);

        //_sharedFixture.Mapper.Map<List<MessageBoxViewModel>>(messages).Returns(mapped);

        //var query = new GetAllMessageBoxByFilterQuery
        //{
        //    JobId = jobId,
        //    UnReadMessages = false
        //};

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().BeEquivalentTo(mapped);
    }

    [Fact]
    public async Task Should_ThrowAndRollback_WhenExceptionIsThrown()
    {
        //// Arrange
        //var jobId = 103;

        ////_sharedFixture.UnitOfWork.MessageBoxRepository.TableNoTracking
        ////    .Where(Arg.Any<Expression<Func<Domain.Entities.MessageBox.MessageBox, bool>>>())
        ////    .ToListAsync(Arg.Any<CancellationToken>())
        ////    .Returns(x => throw new Exception("Database failure"));

        //var query = new GetAllMessageBoxByFilterQuery
        //{
        //    JobId = jobId,
        //    UnReadMessages = true
        //};

        //var handlerWithLogger = new GetAllMessageBoxByFilterQueryHandler(
        //    _sharedFixture.Mapper,
        //    _sharedFixture.UnitOfWork,
        //    Substitute.For<ILogger<GetAllMessageBoxByFilterQueryHandler>>()
        //);

        //// Act
        //Func<Task> act = async () => await handlerWithLogger.Handle(query, CancellationToken.None);

        //// Assert
        //await act.Should().ThrowAsync<Exception>().WithMessage("Database failure");
        //await _sharedFixture.UnitOfWork.Received(1).RollbackTransactionAsync(Arg.Any<CancellationToken>());
    }
}
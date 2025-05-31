using System.Linq.Expressions;
using Application.Features.Service.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Service;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Service;

namespace Application.UnitTest.Features.Service.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllServicesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllServicesQueryHandler _handler;

    public GetAllServicesQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllServicesQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.ServiceRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedServiceList_WhenServicesExist()
    {
        // Arrange
        var services = new List<Domain.Entities.Service.Service>
        {
            new Domain.Entities.Service.Service { Id = 1, ServiceTitle = "خیاطی", IsDeleted = false },
            new Domain.Entities.Service.Service { Id = 2, ServiceTitle = "نجاری", IsDeleted = false }
        };

        var serviceViewModels = new List<ServiceViewModel>
        {
            new ServiceViewModel { Id = 1, ServiceTitle = "خیاطی" },
            new ServiceViewModel { Id = 2, ServiceTitle = "نجاری" }
        };

        _sharedFixture.UnitOfWork.ServiceRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Service.Service, bool>>>())!
            .Returns(Task.FromResult((ICollection<Domain.Entities.Service.Service>)services));

        _sharedFixture.Mapper
            .Map<List<ServiceViewModel>>(services)
            .Returns(serviceViewModels);

        var query = new GetAllServicesQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(serviceViewModels);

        await _sharedFixture.UnitOfWork.ServiceRepository
            .Received(1)
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Service.Service, bool>>>());

        _sharedFixture.Mapper
            .Received(1)
            .Map<List<ServiceViewModel>>(services);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoServiceFound()
    {
        // Arrange
        var services = new List<Domain.Entities.Service.Service>();
        var serviceViewModels = new List<ServiceViewModel>();

        _sharedFixture.UnitOfWork.ServiceRepository
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Service.Service, bool>>>())!
            .Returns(Task.FromResult((ICollection<Domain.Entities.Service.Service>)services));

        _sharedFixture.Mapper
            .Map<List<ServiceViewModel>>(services)
            .Returns(serviceViewModels);

        var query = new GetAllServicesQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEmpty();

        await _sharedFixture.UnitOfWork.ServiceRepository
            .Received(1)
            .GetAllAsync(Arg.Any<Expression<Func<Domain.Entities.Service.Service, bool>>>());

        _sharedFixture.Mapper
            .Received(1)
            .Map<List<ServiceViewModel>>(services);
    }
}
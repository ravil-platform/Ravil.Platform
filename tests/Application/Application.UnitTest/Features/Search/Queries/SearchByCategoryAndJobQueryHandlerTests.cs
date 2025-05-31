using Application.Features.Search.Queries;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Job;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.UnitTest.Features.Search.Queries;

[Collection(CollectionDefinition.SharedFixture)]
public class SearchByCategoryAndJobQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly SearchByCategoryAndJobQueryHandler _handler;

    public SearchByCategoryAndJobQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new SearchByCategoryAndJobQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);
        _sharedFixture.UnitOfWork.JobRepository.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedJobsList_WhenJobsExist()
    {
        // Arrange
        var jobs = new List<Domain.Entities.Job.Job>
        {
            new Domain.Entities.Job.Job { Id = 1, Title = "Doctor" },
            new Domain.Entities.Job.Job { Id = 2, Title = "Lawyer" }
        };

        var jobViewModels = new List<JobSearchResultViewModel>
        {
            new JobSearchResultViewModel {  Title = "Doctor" },
            new JobSearchResultViewModel {  Title = "Lawyer" }
        };

        _sharedFixture.UnitOfWork.JobRepository
            .SearchJob("test", "tehran")
            .Returns(jobs);

        _sharedFixture.Mapper
            .Map<List<JobSearchResultViewModel>>(jobs)
            .Returns(jobViewModels);

        var query = new SearchByCategoryAndJobQuery { Name = "test", CityName = "tehran" };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Jobs.Should().BeEquivalentTo(jobViewModels);

        await _sharedFixture.UnitOfWork.JobRepository.Received(1).SearchJob("test", "tehran");
        _sharedFixture.Mapper.Received(1).Map<List<JobSearchResultViewModel>>(jobs);
    }

    [Fact]
    public async Task Should_ReturnEmptyJobsList_WhenNoJobsFound()
    {
        // Arrange
        var jobs = new List<Domain.Entities.Job.Job>();
        var jobViewModels = new List<JobSearchResultViewModel>();

        _sharedFixture.UnitOfWork.JobRepository
            .SearchJob("none", "shiraz")
            .Returns(jobs);

        _sharedFixture.Mapper
            .Map<List<JobSearchResultViewModel>>(jobs)
            .Returns(jobViewModels);

        var query = new SearchByCategoryAndJobQuery { Name = "none", CityName = "shiraz" };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Jobs.Should().BeEmpty();

        await _sharedFixture.UnitOfWork.JobRepository.Received(1).SearchJob("none", "shiraz");
        _sharedFixture.Mapper.Received(1).Map<List<JobSearchResultViewModel>>(jobs);
    }
}
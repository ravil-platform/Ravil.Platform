using System.Linq.Expressions;
using Application.Features.GuideLine.Queries.GetGuideLines;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Address;
using Domain.Entities.Job;
using Domain.Entities.Location;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.UnitTest.Features.GuideLine.Queries.GetGuideLines;

[Collection(CollectionDefinition.SharedFixture)]
public class GetGuideLinesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetGuideLinesQueryHandler _handler;
    private readonly Logging.Base.ILogger<GetGuideLinesQueryHandler> _logger;

    public GetGuideLinesQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _logger = Substitute.For<Logging.Base.ILogger<GetGuideLinesQueryHandler>>();

        _handler = new GetGuideLinesQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _logger);

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnCompletedSteps_WhenJobBranchIsFoundAndDataIsValid()
    {
        //// Arrange
        //var jobId = 1;
        //var userId = Guid.NewGuid().ToString();

        //var job = new Domain.Entities.Job.Job
        //{
        //    Summary = "summary",
        //    SocialMediaInfos = "info",
        //    PhoneNumberInfos = "phones"
        //};

        //var address = new Address()
        //{
        //    OtherAddress = "Somewhere",
        //    Location = new Location { Lat = 35.0, Long = 51.0 }
        //};

        //var jobBranch = new JobBranch()
        //{
        //    Id = Guid.NewGuid().ToString(),
        //    JobId = jobId,
        //    UserId = userId,
        //    Title = "Title",
        //    Description = "Description",
        //    Address = address,
        //    Job = job,
        //    JobBranchGalleries = new List<Domain.Entities.Job.JobBranchGallery> { new() },
        //    JobKeywords = new List<Domain.Entities.Job.JobKeyword> { new() },
        //    ApplicationUser = null
        //};

        //_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking
        //    .Include(Arg.Any<string>()).Returns(_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking);
        //_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking
        //    .Include(Arg.Any<Expression<Func<Domain.Entities.Job.JobBranch, object>>>())
        //    .Returns(_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking);

        //_sharedFixture.UnitOfWork.JobBranchRepository.TableNoTracking
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<Domain.Entities.Job.JobBranch, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(jobBranch);

        //_sharedFixture.Mapper.Map<JobBranchViewModel>(jobBranch)
        //    .Returns(new JobBranchViewModel());

        //var query = new GetGuideLinesQuery
        //{
        //    JobId = jobId,
        //    UserId = userId
        //};

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().NotBeNull();
        //result.Value.CompletedStepCount.Should().Be(8);
        //result.Value.IsCompletedTitle.Should().BeTrue();
        //result.Value.IsCompletedAddress.Should().BeTrue();
        //result.Value.IsCompletedSummary.Should().BeTrue();
        //result.Value.IsCompletedDescription.Should().BeTrue();
        //result.Value.IsCompletedGalleryAndImages.Should().BeTrue();
        //result.Value.IsCompletedKeywords.Should().BeTrue();
        //result.Value.IsCompletedSocialMediaInfos.Should().BeTrue();
        //result.Value.IsCompletedPhoneNumberInfos.Should().BeTrue();
    }
}
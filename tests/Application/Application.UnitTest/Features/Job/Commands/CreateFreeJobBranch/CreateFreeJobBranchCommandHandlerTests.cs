#region ( namespaces )
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.Json;
using Application.Features.Job.Commands.CreateFreeJobBranch;
using Application.Services.SMS;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Common.Exceptions;
using Common.Utilities.Extensions;
using Common.Utilities.Services.FTP;
using Domain.Entities.Address;
using Domain.Entities.Config;
using Domain.Entities.Job;
using Domain.Entities.Location;
using Domain.Entities.User;
using Enums;
using FluentAssertions;
using FluentValidation;
using Logging.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Job;
#endregion

namespace Application.UnitTest.Features.Job.Commands.CreateFreeJobBranch;

[Collection(CollectionDefinition.SharedDistributedCacheFixture)]
public class CreateFreeJobBranchCommandHandlerTests
{
    #region ( Setup Fixture )
    private readonly SharedFixture _sharedFixture;
    private readonly CreateFreeJobBranchCommandHandler _handler;

    public CreateFreeJobBranchCommandHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;

        var smsSender = Substitute.For<ISmsSender>();
        var userManager = Substitute.For<UserManager<ApplicationUser>>(
            Substitute.For<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        httpContextAccessor.HttpContext.Returns(new DefaultHttpContext
        {
            User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user-123")
            }))
        });

        var ftpService = Substitute.For<IFtpService>();
        var logger = Substitute.For<ILogger<CreateFreeJobBranchCommandHandler>>();

        _handler = new CreateFreeJobBranchCommandHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            smsSender,
            httpContextAccessor,
            userManager,
            ftpService,
            logger
        );
    }
    #endregion

    #region ( Should Return Job Branch ViewModel When Request Is Valid )
    [Fact]
    public async Task Should_ReturnJobBranchViewModel_WhenRequestIsValid()
    {
        // Arrange
        var jobId = 100;
        var branchId = Guid.NewGuid().ToString();
        var locationId = Guid.NewGuid().ToString();

        var request = new CreateFreeJobBranchCommand
        {
            Job = new CreateJobViewModel
            {
                Title = "Test Job",
                Route = "test-job",
                PhoneNumberInfos = "[]",
                SocialMediaInfos = "[]",
                Content = "job content"
            },
            JobBranch = new CreateJobBranchViewModel
            {
                Title = "Test Branch",
                Description = "Branch Desc",
                JobTimeWorkType = JobTimeWorkType.WorkAllTime,
                Gallery = new List<IFormFile>(),
                SmallPictureFile = null,
                LargePictureFile = null,
                BranchVideo = null
            },
            FullAddress = "Test Address",
            CityId = 1,
            StateId = 2,
            Lat = 35.7,
            Long = 51.4
        };

        var job = new Domain.Entities.Job.Job { Id = jobId };
        var branch = new JobBranch
        {
            Id = branchId,
            Title = "Test Branch",
            Job = null,
            ApplicationUser = null,
            Address = null
        };

        var location = new Location
        {
            Id = locationId,
            Lat = request.Lat,
            Long = request.Long
        };

        var address = new Address
        {
            Id = Guid.NewGuid().ToString(),
            JobBranchId = branch.Id,
            CityId = request.CityId,
            StateId = request.StateId,
            LocationId = locationId,
            OtherAddress = request.FullAddress,
            PostalCode = "",
            PostalAddress = "",
            Neighbourhood = ""
        };

        _sharedFixture.Mapper.Map<Domain.Entities.Job.Job>(request.Job).Returns(job);
        _sharedFixture.Mapper.Map<JobBranch>(request.JobBranch).Returns(branch);
        _sharedFixture.Mapper.Map<JobBranchViewModel>(branch).Returns(new JobBranchViewModel
        {
            Id = branchId,
            Title = branch.Title,
            Description = branch.Description
        });

        _sharedFixture.UnitOfWork.ShortLinkRepository
            .GenerateShortLink(5, ShortLinkType.JobBranch)
            .Returns("short");

        _sharedFixture.UnitOfWork.ConfigRepository.TableNoTracking
            .Returns(new List<Config>
            {
            new Config { OrderNotificationPhoneNumber = "09120000000" }
            }.AsQueryable());

        _sharedFixture.UnitOfWork.ApplicationUserRepository
            .GetByPredicate(Arg.Any<Expression<Func<ApplicationUser, bool>>>())
            .Returns(new ApplicationUser
            {
                Id = "user-123",
                Firstname = "Ali",
                Lastname = "Rezaei"
            });

        _sharedFixture.UnitOfWork.LocationRepository
            .InsertAsync(Arg.Do<Location>(loc => loc.Id = locationId))
            .Returns(Task.CompletedTask);

        _sharedFixture.UnitOfWork.LocationRepository
            .GetByIdAsync(locationId)
            .Returns(location);

        _sharedFixture.UnitOfWork.AddressRepository
            .InsertAsync(Arg.Any<Address>())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Title.Should().Be(branch.Title);
        result.Value.Id.Should().Be(branch.Id.ToString());

        await _sharedFixture.UnitOfWork.JobRepository.Received(1).BeginTransactionAsync();
        await _sharedFixture.UnitOfWork.JobRepository.Received(1).InsertAsync(Arg.Any<Domain.Entities.Job.Job>());
        await _sharedFixture.UnitOfWork.JobBranchRepository.Received(1).InsertAsync(Arg.Any<JobBranch>());
        await _sharedFixture.UnitOfWork.JobRepository.Received(1).CommitTransactionAsync();

        await _sharedFixture.UnitOfWork.LocationRepository.Received(1).InsertAsync(Arg.Any<Location>());
        await _sharedFixture.UnitOfWork.LocationRepository.Received(1).GetByIdAsync(locationId);
        await _sharedFixture.UnitOfWork.AddressRepository.Received(1).InsertAsync(Arg.Any<Address>());
        await _sharedFixture.UnitOfWork.JobBranchRepository.Received(1).UpdateAsync(Arg.Any<JobBranch>());
    }
    #endregion

    #region ( Should Throw Bad Request Exception When Job Is Null )
    [Fact]
    public async Task Should_ThrowBadRequestException_WhenJobIsNull()
    {
        // Arrange
        var request = new CreateFreeJobBranchCommand
        {
            Job = null,
            JobBranch = new CreateJobBranchViewModel
            {
                Title = "Test Branch",
                Description = "Branch Desc",
                JobTimeWorkType = JobTimeWorkType.WorkAllTime
            },
            FullAddress = "Test Address",
            CityId = 1,
            StateId = 2,
            Lat = 35.7,
            Long = 51.4
        };

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should()
            .ThrowAsync<BadRequestException>();
    }
    #endregion

    #region ( Should Save Job With Default Route When Route Is Empty )
    [Fact]
    public async Task Should_SaveJobWithDefaultRoute_WhenRouteIsEmpty()
    {
        // Arrange
        var jobId = 150;
        var branchId = Guid.NewGuid().ToString();

        var request = new CreateFreeJobBranchCommand
        {
            Job = new CreateJobViewModel
            {
                Title = "My Job Title",
                Route = "",
                PhoneNumberInfos = "[]",
                SocialMediaInfos = "[]",
                Content = "job content"
            },
            JobBranch = new CreateJobBranchViewModel
            {
                Title = "Test Branch",
                Description = "Branch Desc",
                JobTimeWorkType = JobTimeWorkType.WorkAllTime,
                Gallery = new List<IFormFile>()
            },
            FullAddress = "Test Address",
            CityId = 1,
            StateId = 2,
            Lat = 35.7,
            Long = 51.4
        };

        var job = new Domain.Entities.Job.Job { Id = jobId };
        var jobBranch = new JobBranch
        {
            Id = branchId,
            Job = null,
            ApplicationUser = null,
            Address = null
        };

        _sharedFixture.Mapper.Map<Domain.Entities.Job.Job>(request.Job).Returns(job);
        _sharedFixture.Mapper.Map<JobBranch>(request.JobBranch).Returns(jobBranch);
        _sharedFixture.Mapper.Map<JobBranchViewModel>(jobBranch).Returns(new JobBranchViewModel
        {
            Id = branchId,
            Title = "Test Branch"
        });

        _sharedFixture.UnitOfWork.ShortLinkRepository.EncodePersianLink(request.Job.Title).Returns("encoded-title");
        _sharedFixture.UnitOfWork.ShortLinkRepository.GenerateShortLink(Arg.Any<int>(), Arg.Any<ShortLinkType>())
            .Returns("short-link");

        _sharedFixture.UnitOfWork.LocationRepository.GetByIdAsync(Arg.Any<Guid>())
            .Returns(new Location { Id = Guid.NewGuid().ToString(), Lat = request.Lat, Long = request.Long });

        _sharedFixture.UnitOfWork.ApplicationUserRepository.GetByPredicate(Arg.Any<Expression<Func<ApplicationUser, bool>>>())
            .Returns(new ApplicationUser { Id = "user-id", Firstname = "Ali", Lastname = "Rezaei" });

        _sharedFixture.UnitOfWork.ConfigRepository.TableNoTracking
            .Returns(new List<Config> { new Config { OrderNotificationPhoneNumber = "09120000000" } }.AsQueryable());

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        job.Route.Should().Be("encoded-title");

        await _sharedFixture.UnitOfWork.JobRepository.Received(1).InsertAsync(Arg.Is<Domain.Entities.Job.Job>(j =>
            j.Route == "encoded-title"
        ));
    }
    #endregion

    #region ( Should Not Insert Job Time Works When Job TimeWork Type Is Not Some Time )
    [Fact]
    public async Task Should_NotInsertJobTimeWorks_WhenJobTimeWorkTypeIsNotSomeTime()
    {
        // Arrange
        var jobId = 100;
        var branchId = Guid.NewGuid().ToString();

        var request = new CreateFreeJobBranchCommand
        {
            Job = new CreateJobViewModel
            {
                Title = "Test Job",
                Route = "test-job",
                PhoneNumberInfos = "[]",
                SocialMediaInfos = "[]",
                Content = "job content"
            },
            JobBranch = new CreateJobBranchViewModel
            {
                Title = "Branch",
                Description = "Desc",
                JobTimeWorkType = JobTimeWorkType.WorkAllTime, // تست برای حالتی که نباید درج شود
            },
            JobTimeWork = JsonSerializer.Serialize(new List<JobTimeWorkViewModel>
        {
            new JobTimeWorkViewModel
            {
                DayOfWeekId = 1,
                StartTime = "08:00",
                EndTime = "17:00"
            }
        }),
            Lat = 35.7,
            Long = 51.4,
            CityId = 1,
            StateId = 1,
            FullAddress = "Test Address"
        };

        var job = new Domain.Entities.Job.Job { Id = jobId };
        var jobBranch = new JobBranch
        {
            Id = branchId,
            Job = null,
            ApplicationUser = null,
            Address = null
        };

        _sharedFixture.Mapper.Map<Domain.Entities.Job.Job>(request.Job).Returns(job);
        _sharedFixture.Mapper.Map<JobBranch>(request.JobBranch).Returns(jobBranch);
        _sharedFixture.Mapper.Map<JobBranchViewModel>(jobBranch).Returns(new JobBranchViewModel { Id = branchId, Title = "Branch" });

        _sharedFixture.UnitOfWork.ShortLinkRepository.GenerateShortLink(Arg.Any<int>(), Arg.Any<ShortLinkType>()).Returns("short");
        _sharedFixture.UnitOfWork.ShortLinkRepository.EncodePersianLink(Arg.Any<string>()).Returns("test-job");

        _sharedFixture.UnitOfWork.LocationRepository.GetByIdAsync(Arg.Any<Guid>())
            .Returns(new Location { Id = Guid.NewGuid().ToString(), Lat = request.Lat, Long = request.Long });

        _sharedFixture.UnitOfWork.ApplicationUserRepository.GetByPredicate(Arg.Any<Expression<Func<ApplicationUser, bool>>>())
            .Returns(new ApplicationUser { Id = "user-id", Firstname = "Ali", Lastname = "Rezaei" });

        _sharedFixture.UnitOfWork.ConfigRepository.TableNoTracking
            .Returns(new List<Config> { new Config { OrderNotificationPhoneNumber = "09120000000" } }.AsQueryable());

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Title.Should().Be("Branch");

        await _sharedFixture.UnitOfWork.JobTimeWorkRepository
            .DidNotReceive()
            .InsertAsync(Arg.Any<JobTimeWork>());
    }
    #endregion
}
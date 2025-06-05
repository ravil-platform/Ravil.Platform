using System.Linq.Expressions;
using Application.Features.GuideLine.Commands.GuideLineCompletion;
using Application.Services.SMS;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Application.UnitTest.Helpers;
using Common.Utilities.Services.FTP;
using Domain.Entities.User;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Job.GuideLines;

namespace Application.UnitTest.Features.Faq.Queries.GetAllFaqCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GuideLineCompletionCommandHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GuideLineCompletionCommandHandler _handler;
    private readonly IFtpService _ftpService;
    private readonly ISmsSender _smsSender;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly Logging.Base.ILogger<GuideLineCompletionCommandHandler> _logger;

    public GuideLineCompletionCommandHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;

        _ftpService = Substitute.For<IFtpService>();
        _smsSender = Substitute.For<ISmsSender>();
        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        //_userManager = SubstituteHelper.CreateUserManager<ApplicationUser>();
        _logger = Substitute.For<Logging.Base.ILogger<GuideLineCompletionCommandHandler>>();

        _handler = new GuideLineCompletionCommandHandler(
            _sharedFixture.Mapper,
            _smsSender,
            _sharedFixture.UnitOfWork,
            _ftpService,
            _userManager,
            _httpContextAccessor,
            _logger);

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnGuideLineCompletionWithCompletedTitle_WhenTitleIsProvided()
    {
        //// Arrange
        //var jobBranchId = Guid.NewGuid().ToString();

        //var job = new Domain.Entities.Job.Job { Title = "" };
        //var jobBranch = new Domain.Entities.Job.JobBranch
        //{
        //    Id = jobBranchId,
        //    Title = "",
        //    Job = job,
        //    ApplicationUser = null,
        //    Address = null,
        //};

        //_sharedFixture.UnitOfWork.JobBranchRepository.Table
        //    .Include(Arg.Any<string>()).Returns(_sharedFixture.UnitOfWork.JobBranchRepository.Table);
        //_sharedFixture.UnitOfWork.JobBranchRepository.Table
        //    .Include(Arg.Any<Expression<Func<Domain.Entities.Job.JobBranch, object>>>())
        //    .Returns(_sharedFixture.UnitOfWork.JobBranchRepository.Table);

        //_sharedFixture.UnitOfWork.JobBranchRepository.Table
        //    .SingleOrDefaultAsync(Arg.Any<Expression<Func<Domain.Entities.Job.JobBranch, bool>>>(), Arg.Any<CancellationToken>())
        //    .Returns(jobBranch);

        //_sharedFixture.Mapper.Map<GuideLineCompletionViewModel>(jobBranch)
        //    .Returns(new GuideLineCompletionViewModel());

        //_sharedFixture.UnitOfWork.JobBranchRepository.AttachAsync(Arg.Any<Domain.Entities.Job.JobBranch>()).Returns(Task.CompletedTask);
        //_sharedFixture.UnitOfWork.SaveAsync().Returns(1);

        //var command = new GuideLineCompletionCommand
        //{
        //    JobBranchId = jobBranchId,
        //    Title = "New Title"
        //};

        //// Act
        //var result = await _handler.Handle(command, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        ////result.IsCompletedTitle.Should().BeTrue();
        ////result.CompletedStepCount.Should().Be(1);
        ////result.TotalStepCount.Should().Be(8);

        //await _sharedFixture.UnitOfWork.JobBranchRepository.Received(1)
        //    .AttachAsync(Arg.Is<Domain.Entities.Job.JobBranch>(b => b.Title == "New Title" && b.Job.Title == "New Title"));

        //await _sharedFixture.UnitOfWork.Received(1).SaveAsync();
    }
}
using System.Collections;
using AngleSharp.Common;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetJobOverView;

public class JobOverViewQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<JobOverViewQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<JobOverViewQuery, JobOverViewViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<JobOverViewQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<JobOverViewViewModel>> Handle(JobOverViewQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job OverView Query )

        var result = new Result<JobOverViewViewModel>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            #endregion

            var jobInfos = await UnitOfWork.JobInfoRepository.TableNoTracking
                .Where(a => a.JobId == request.JobId)
                .ToListAsync(cancellationToken: cancellationToken);

            var info = new JobOverViewViewModel();
            info.TotalViewCount = jobInfos.Sum(a => a.Visit);
            info.TotalContactRequestCount = jobInfos.Sum(a => a.ClickOnCall) +
                jobInfos.Sum(a => a.ClickOnMap) + jobInfos.Sum(a => a.ClickOnChat);


            result.WithValue(info);
            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
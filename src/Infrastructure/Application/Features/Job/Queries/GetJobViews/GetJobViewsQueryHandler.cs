using System.Collections;
using AngleSharp.Common;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetJobViews;

public class GetJobViewsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetJobViewsQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetJobViewsQuery, JobViewsViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetJobViewsQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<JobViewsViewModel>> Handle(GetJobViewsQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job Views Query )

        var result = new Result<JobViewsViewModel>();

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
            
            var latestWeekJobsInfo = await UnitOfWork.JobInfoRepository.TableNoTracking
                .Where(a => a.CreateAt.Day <= DateTime.UtcNow.Day && a.CreateAt.Day >= DateTime.UtcNow.AddDays(-14).Day)
                .Where(a => a.JobId == request.JobId && a.Visit > 0)
                .ToListAsync(cancellationToken: cancellationToken);

            var jobViews = new JobViewsViewModel();
            jobViews.TotalClicks = latestWeekJobsInfo.Sum(a => a.Visit);

            jobViews.Data = latestWeekJobsInfo.GroupBy(a => a.CreateAt)
                .Select(group => new ClickViewJobsViewModel
                {
                    Date = group.Key.ToShamsiDateDashFormat(),
                    WithAds = group.Where(a => a.IsActiveAds).Sum(a => a.Visit),
                    WithoutAds = group.Where(a => !a.IsActiveAds).Sum(a => a.Visit)
                }).ToList();


            result.WithValue(jobViews);
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
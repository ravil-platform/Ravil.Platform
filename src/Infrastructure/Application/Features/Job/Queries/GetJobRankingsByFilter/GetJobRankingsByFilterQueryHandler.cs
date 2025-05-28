using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Resources.Messages;
using Domain.Entities.Histories.Enums;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetJobRankingsByFilter;

public class GetJobRankingsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetJobRankingsByFilterQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetJobRankingsByFilterQuery, List<JobRankingViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetJobRankingsByFilterQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<JobRankingViewModel>>> Handle(GetJobRankingsByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job Rankings By Filter Query )

        var result = new Result<List<JobRankingViewModel>>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            #region ( BusinessOwner )

            /*var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);*/

            #endregion

            #endregion

            var fromDate = request.FromDate.HasValue ? DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value).DateTime : DateTime.UtcNow;
            var toDate = request.ToDate.HasValue ? DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value).DateTime : DateTime.UtcNow.AddDays(-14);

            var jobRankingsCache = await DistributedCache.GetAsync<List<JobRankingViewModel>>(CacheKeys.GetJobRankingsByFilterQuery(request.JobId));
            if (jobRankingsCache != null)
            {
                result.WithValue(jobRankingsCache);
            }
            else
            {
                var jobRankingHistories = await UnitOfWork.JobRankingHistoryRepository.TableNoTracking
                .Where(a => a.JobId == request.JobId).OrderBy(a => a.CreateAt)
                //.Where(a => a.CreateAt.Day >= fromDate.Day && a.CreateAt.Day <= toDate.Day)
                .ToListAsync(cancellationToken: cancellationToken);

                var latestWeekJobsAction = await UnitOfWork.ActionHistoriesRepository.TableNoTracking
                    //.Where(a => a.Time.Day >= fromDate.Day && a.Time.Day <= toDate.Day)
                    .Where(a => a.JobId == request.JobId.ToString()
                        && (a.ActionType == ActionType.ClickOnChat.ToString()
                        || a.ActionType == ActionType.ClickOnImages.ToString()
                        || a.ActionType == ActionType.ClickOnWebSite.ToString()
                        || a.ActionType == ActionType.ClickOnMap.ToString()
                        || a.ActionType == ActionType.ClickOnCall.ToString()
                        || a.ActionType == ActionType.ClickOnCard.ToString()
                        || a.ActionType == ActionType.JobPageView.ToString()))
                    .OrderBy(a => a.Time).ToListAsync(cancellationToken: cancellationToken);

                #region ( Set Cache )
                
                var jobRankingsViewModelsCache = new List<JobRankingViewModel>();
                jobRankingsViewModelsCache.AddRange(jobRankingHistories.GroupBy(a => a.PageUrl)
                    .Select(group => new JobRankingViewModel
                    {
                        PageUrl = WebUtility.UrlDecode(group.Key),
                        AveragePosition = Convert.ToDouble(jobRankingHistories.Where(a => a.PageUrl.Equals(group.Key)).Sum(a => a.Position) / jobRankingHistories.Count(a => a.PageUrl.Equals(group.Key))),
                        ClickCount = latestWeekJobsAction?.Count(a => a.PageUrl == group.Key) ?? 0
                    }).ToList());

                await DistributedCache.SetCache(key: CacheKeys.GetJobRankingsByFilterQuery(request.JobId),
                    value: jobRankingsViewModelsCache,
                    options: new DistributedCache.CacheOptions
                    {
                        ExpireSlidingCacheFromMinutes = 4 * 60,
                        AbsoluteExpirationCacheFromMinutes = 24 * 60
                    });

                #endregion

                jobRankingHistories = jobRankingHistories.Where(a => a.CreateAt >= fromDate && a.CreateAt <= toDate).ToList();
                latestWeekJobsAction = latestWeekJobsAction.Where(a => a.Time >= fromDate && a.Time <= toDate).ToList();

                var jobRankingsViewModels = new List<JobRankingViewModel>();
                jobRankingsViewModels.AddRange(jobRankingHistories.GroupBy(a => a.PageUrl)
                .Select(group => new JobRankingViewModel
                {
                    PageUrl = WebUtility.UrlDecode(group.Key),
                    AveragePosition = Convert.ToDouble(jobRankingHistories.Where(a => a.PageUrl.Equals(group.Key)).Sum(a => a.Position) / jobRankingHistories.Count(a => a.PageUrl.Equals(group.Key))),
                    ClickCount = latestWeekJobsAction?.Count(a => a.PageUrl == group.Key) ?? 0
                }).ToList());

                result.WithValue(jobRankingsViewModels);
            }

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
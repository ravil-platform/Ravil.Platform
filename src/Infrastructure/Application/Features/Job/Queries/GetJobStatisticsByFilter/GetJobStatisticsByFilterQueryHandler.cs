using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using Resources.Messages;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetJobStatisticsByFilter;

public class GetJobStatisticsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetJobStatisticsByFilterQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetJobStatisticsByFilterQuery, List<JobStatisticsViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetJobStatisticsByFilterQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<JobStatisticsViewModel>>> Handle(GetJobStatisticsByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job Statistics By Filter Query )

        var result = new Result<List<JobStatisticsViewModel>>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await DistributedCache.GetOrSet(CacheKeys.GetUserByIdQuery(businessOwnerId!),
                async () => await UserManager.FindByIdAsync(businessOwnerId!),
                options: new DistributedCache.CacheOptions
                {
                    ExpireSlidingCacheFromMinutes = 4 * 60,
                    AbsoluteExpirationCacheFromMinutes = 24 * 60
                });

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            #endregion

            var fromDate = request.FromDate.HasValue ? DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value).DateTime : DateTime.UtcNow;
            var toDate = request.ToDate.HasValue ? DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value).DateTime : DateTime.UtcNow.AddDays(-14);

            var jobStatisticsCache = await DistributedCache.GetAsync<List<JobStatisticsViewModel>>(CacheKeys.GetJobStatisticsByFilterQuery(request.JobId));
            if (jobStatisticsCache != null)
            {
                jobStatisticsCache = jobStatisticsCache.Where(a => a.CreateAt >= fromDate && a.CreateAt <= toDate).ToList();
                result.WithValue(jobStatisticsCache);
            }
            else
            {
                var jobStatistics = await UnitOfWork.JobInfoRepository.TableNoTracking
                    .Where(a => a.JobId == request.JobId).OrderBy(a => a.CreateAt)
                    .ProjectTo<JobStatisticsViewModel>(Mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (!jobStatistics.Any())
                {
                    #region ( Set Cache )

                    await DistributedCache.SetCache(key: CacheKeys.GetJobStatisticsByFilterQuery(request.JobId),
                        value: jobStatistics,
                        options: new DistributedCache.CacheOptions
                        {
                            ExpireSlidingCacheFromMinutes = 4 * 60,
                            AbsoluteExpirationCacheFromMinutes = 24 * 60
                        });

                    #endregion

                    jobStatistics = jobStatistics.Where(a => a.CreateAt >= fromDate && a.CreateAt <= toDate).ToList();
                    result.WithValue(jobStatistics);
                }
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
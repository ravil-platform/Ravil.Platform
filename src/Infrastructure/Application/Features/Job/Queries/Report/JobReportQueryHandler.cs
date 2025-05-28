using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.Report;

public class JobReportQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<JobReportQueryHandler> logger,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<JobReportQuery, List<SubscriptionClickViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<JobReportQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<SubscriptionClickViewModel>>> Handle(JobReportQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Job Reports Query )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        #endregion

        try
        {
            var subscriptionClicksCache = await DistributedCache.GetAsync<List<SubscriptionClickViewModel>>(CacheKeys.JobReportQuery(request.JobId));
            if (subscriptionClicksCache != null)
            {
                if (request is { FromDate: not null, ToDate: not null })
                {
                    var fromDate = request.FromDate.Value;
                    var toDate = request.ToDate.Value;

                    subscriptionClicksCache = subscriptionClicksCache.Where(a => a.ClickedTimeStamp >= fromDate && a.ClickedTimeStamp <= toDate).ToList();
                }
                else
                {
                    subscriptionClicksCache = subscriptionClicksCache.Where(a => a.ClickedTimeStamp == new DateTimeOffset(DateTime.UtcNow.AddDays(-1)).ToUnixTimeSeconds()).ToList();
                }

                var result = Mapper.Map<List<SubscriptionClickViewModel>>(subscriptionClicksCache);

                result = result.Where(a => a.ClickType == request.ClickType).ToList();
                return result;
            }
            else
            {
                var subscriptionClicks = await UnitOfWork.SubscriptionClickRepository.TableNoTracking
                    .Include(a => a.Click)
                    .Where(a => a.JobId == request.JobId)
                    .OrderByDescending(a => a.ClickedTime)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (!subscriptionClicks.Any())
                    return Result.Ok(new List<SubscriptionClickViewModel>());

                if (request is { FromDate: not null, ToDate: not null })
                {
                    var fromDate = DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value);
                    var toDate = DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value);

                    subscriptionClicks = subscriptionClicks.Where(a => a.ClickedTime.Day >= fromDate.Day && a.ClickedTime.Day <= toDate.Day).ToList();
                }
                else
                {
                    subscriptionClicks = subscriptionClicks.Where(a => a.ClickedTime.Day == DateTime.Now.Day - 1).ToList();
                }

                var result = Mapper.Map<List<SubscriptionClickViewModel>>(subscriptionClicks);

                #region ( Set Cache )

                await DistributedCache.SetCache(CacheKeys.JobReportQuery(request.JobId), result,
                    options: new DistributedCache.CacheOptions
                    {
                        ExpireSlidingCacheFromMinutes = 4 * 60,
                        AbsoluteExpirationCacheFromMinutes = 24 * 60
                    });

                #endregion

                result = result.Where(a => a.ClickType == request.ClickType).ToList();
                return result;
            }
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            throw;
        }

        #endregion
    }
}
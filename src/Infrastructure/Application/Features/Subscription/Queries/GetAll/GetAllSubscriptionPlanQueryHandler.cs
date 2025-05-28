using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Subscription.Queries.GetAll;

public class GetAllSubscriptionPlanQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache,
    Logging.Base.ILogger<GetAllSubscriptionPlanQueryHandler> logger)
: IRequestHandler<GetAllSubscriptionPlanQuery, List<SubscriptionViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected Logging.Base.ILogger<GetAllSubscriptionPlanQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<SubscriptionViewModel>>> Handle(GetAllSubscriptionPlanQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All Subscription Plans Query )

        try
        {
            var subscriptionPlans = await DistributedCache.GetOrSet(CacheKeys.GetAllSubscriptionPlanQuery(),
                func: async () =>
                {
                    return await UnitOfWork.SubscriptionRepository.TableNoTracking
                        .Include(s => s.SubscriptionFeatures)
                        .Where(a => a.IsActive)
                        .ProjectTo<SubscriptionViewModel>(Mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken: cancellationToken);
                },
                options: new DistributedCache.CacheOptions
                {
                    ExpireSlidingCacheFromMinutes = 4 * 60,
                    AbsoluteExpirationCacheFromMinutes = 24 * 60
                });

            if (subscriptionPlans == null || !subscriptionPlans.Any()) 
                return Result.Ok();

            if (request.DurationType.HasValue)
            {
                subscriptionPlans = subscriptionPlans.Where(a => a.DurationType == request.DurationType).ToList();
            }

            if (request.SubscriptionType.HasValue)
            {
                subscriptionPlans = subscriptionPlans.Where(a => a.Type == request.SubscriptionType).ToList();
            }

            return subscriptionPlans;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
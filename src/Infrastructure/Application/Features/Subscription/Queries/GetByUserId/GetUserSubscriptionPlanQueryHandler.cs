using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using Resources.Messages;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Subscription.Queries.GetByUserId;

public class GetUserSubscriptionPlanQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache,
    Logging.Base.ILogger<GetUserSubscriptionPlanQueryHandler> logger)
: IRequestHandler<GetUserSubscriptionPlanQuery, UserSubscriptionViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected Logging.Base.ILogger<GetUserSubscriptionPlanQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<UserSubscriptionViewModel>> Handle(GetUserSubscriptionPlanQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Active UserSubscription Plan Query )

        try
        {
            var userSubscriptionPlan = await DistributedCache.GetOrSet(CacheKeys.GetUserSubscriptionPlanQuery(request.UserId),
                func: async () =>
                {
                    return await UnitOfWork.UserSubscriptionRepository.TableNoTracking
                        .Where(a => a.IsActive && a.IsFinally && a.UserId == request.UserId && a.EndDate.Day >= DateTime.UtcNow.Day)
                        .ProjectTo<UserSubscriptionViewModel>(Mapper.ConfigurationProvider)
                        .OrderByDescending(us => us.StartDate)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                },
                options: new DistributedCache.CacheOptions
                {
                    ExpireSlidingCacheFromMinutes = 4 * 60,
                    AbsoluteExpirationCacheFromMinutes = 24 * 60
                });

            if (userSubscriptionPlan is null)
                return Result.Fail(Validations.NotFoundException);

            return userSubscriptionPlan;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
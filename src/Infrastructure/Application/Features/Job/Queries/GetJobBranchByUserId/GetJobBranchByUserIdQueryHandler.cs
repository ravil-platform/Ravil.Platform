using Microsoft.Extensions.Caching.Distributed;
using Constants.Caching;

namespace Application.Features.Job.Queries.GetJobBranchByUserId;

public class GetJobBranchByUserIdQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
: IRequestHandler<GetJobBranchByUserIdQuery, JobBranchViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<JobBranchViewModel>> Handle(GetJobBranchByUserIdQuery request, CancellationToken cancellationToken)
    {
        #region ( Get JobBranch By UserId Query )

        var result = await DistributedCache.GetOrSet(CacheKeys.GetJobBranchByUserIdQuery(request.UserId),
            func: async () => await UnitOfWork.JobBranchRepository.GetJobBranchByUserId(request.UserId, cancellationToken),
            new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 12 * 60
            });

        if (result is null)
        {
            await DistributedCache.RemoveAsync(CacheKeys.GetJobBranchByUserIdQuery(request.UserId), cancellationToken);

            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        #region ( DetectIsAdsJob )

        var currentActiveUserSubscription = await UnitOfWork.UserSubscriptionRepository.TableNoTracking.Include(a => a.Subscription)
            .Where(a => !string.IsNullOrWhiteSpace(jobBranchViewModel.UserId) && a.UserId == jobBranchViewModel.UserId)
            .Where(a => a.IsActive && a.IsFinally && a.EndDate.Day >= DateTime.UtcNow.Day)
            .OrderByDescending(currentSub => currentSub.StartDate)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (currentActiveUserSubscription is not null)
        {
            var jobOwnerAdsClickSetting = await UnitOfWork.ClickAdsSettingRepository.TableNoTracking
                .Where(a => a.UserId == jobBranchViewModel.UserId && a.Status)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (jobOwnerAdsClickSetting is null)
                return Result.Fail(Resources.Messages.Validations.NotFoundException);

            if (jobBranchViewModel.Keywords != null && jobOwnerAdsClickSetting.Status)
            {
                jobBranchViewModel.IsAds = true;
                jobBranchViewModel.SubscriptionId = currentActiveUserSubscription.SubscriptionId;
                jobBranchViewModel.SubscriptionType = currentActiveUserSubscription.Subscription.Type;
            }
            else
            {
                jobBranchViewModel.IsAds = false;
                jobBranchViewModel.SubscriptionId = currentActiveUserSubscription.SubscriptionId;
                jobBranchViewModel.SubscriptionType = currentActiveUserSubscription.Subscription.Type;
            }
        }
        else
        {
            jobBranchViewModel.IsAds = false;
            jobBranchViewModel.SubscriptionType = SubscriptionType.Simple;
            jobBranchViewModel.SubscriptionId = currentActiveUserSubscription?.SubscriptionId;
        }

        #endregion

        return jobBranchViewModel;

        #endregion
    }
}
﻿using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetJobBranchById;

public class GetJobBranchByIdQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetJobBranchByIdQuery, JobBranchViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<JobBranchViewModel>> Handle(GetJobBranchByIdQuery request, CancellationToken cancellationToken)
    {
        #region ( Get JobBranch By Id Query )

        var result = await DistributedCache.GetOrSet(CacheKeys.GetJobBranchByIdQuery(request.Id),
            func: async () => await UnitOfWork.JobBranchRepository.GetJobBranchById(request.Id, cancellationToken),
            new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 12 * 60
            });

        if (result is null)
        {
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
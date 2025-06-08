using Microsoft.Extensions.Caching.Distributed;
using Resources.Messages;
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

            return Result.Fail(Validations.NotFoundException);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;

        #endregion
    }
}
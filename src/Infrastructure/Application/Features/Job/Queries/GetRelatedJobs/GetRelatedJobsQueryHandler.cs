using Common.Utilities.Extensions;
using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetRelatedJobs;

public class GetRelatedJobsQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetRelatedJobsQuery, List<JobBranchViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetRelatedJobsQuery request, CancellationToken cancellationToken)
    {
        var jobBranches = await DistributedCache.GetOrSet(CacheKeys.GetRelatedJobsQuery(request.JobId),
            async () => await UnitOfWork.JobBranchRepository.GetRelatedJobBranches(request.JobId, request.Take),
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 8 * 60,
                AbsoluteExpirationCacheFromMinutes = 72 * 60
            });

        var result = Mapper.Map<List<JobBranchViewModel>>(jobBranches);

        return result;
    }
}
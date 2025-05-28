using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetBestJobs;

public class GetBestJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetBestJobsQuery, List<JobViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<List<JobViewModel>>> Handle(GetBestJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await DistributedCache.GetOrSet(CacheKeys.GetBestJobsQuery(),
            async () => await UnitOfWork.JobRepository.GetBestJobs(request.Take),
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 12 * 60,
                AbsoluteExpirationCacheFromMinutes = 72 * 60
            });

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}
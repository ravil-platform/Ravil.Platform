using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetNewestJobs;

public class GetNewestJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetNewestJobsQuery, List<JobViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<List<JobViewModel>>> Handle(GetNewestJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await DistributedCache.GetOrSet(CacheKeys.GetNewestJobsQuery(),
            async () => await UnitOfWork.JobRepository.GetNewestJobs(request.Take),
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 24 * 60
            });

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}
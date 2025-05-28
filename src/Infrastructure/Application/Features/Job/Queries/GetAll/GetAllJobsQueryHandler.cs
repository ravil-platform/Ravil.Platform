using Constants.Caching;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetAll;

public class GetAllJobsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    : IRequestHandler<GetAllJobsQuery, List<JobBranchViewModel>>
{
    #region ( Dependencies )

    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;

    #endregion

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
    {
        var jobBranchViewModels = await DistributedCache.GetOrSet(CacheKeys.GetAllJobsQuery(),
            async () =>
            {
                return await UnitOfWork.JobBranchRepository.TableNoTracking
                    .Include(a => a.Job)
                    .ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);
            },
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 24 * 60,
                AbsoluteExpirationCacheFromMinutes = 7 * 24 * 60
            });

        if (jobBranchViewModels is null)
        {
            return Result.Ok();
        }

        return jobBranchViewModels;
    }
}
using Constants.Caching;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetJobBranchByRoute;

public class GetJobBranchByRouteQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    : IRequestHandler<GetJobBranchByRouteQuery, JobBranchViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<JobBranchViewModel>> Handle(GetJobBranchByRouteQuery request, CancellationToken cancellationToken)
    {
        #region ( Get JobBranch By Route Query )

        var result = await DistributedCache.GetOrSet(CacheKeys.GetJobBranchByRouteQuery(request.Route),
            async () => await UnitOfWork.JobBranchRepository.GetJobBranchByRoute(request.Route, cancellationToken),
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 12 * 60
            });

        if (result is null)
        {
            return Result.Fail(Validations.NotFoundException);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;

        #endregion
    }
}
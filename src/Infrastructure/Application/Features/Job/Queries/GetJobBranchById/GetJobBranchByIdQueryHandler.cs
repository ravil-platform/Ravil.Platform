using Constants.Caching;
using Resources.Messages;
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
            return Result.Fail(Validations.NotFoundException);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;

        #endregion
    }
}
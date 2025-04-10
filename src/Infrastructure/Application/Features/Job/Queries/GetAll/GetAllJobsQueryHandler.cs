using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Job.Queries.GetAll;

public class GetAllJobsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
    : IRequestHandler<GetAllJobsQuery, List<JobBranchViewModel>>
{
    protected IMemoryCache MemoryCache { get; } = memoryCache;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
    {
        if (!MemoryCache.TryGetValue(nameof(GetAllJobsQuery), out List<JobBranchViewModel>? jobBranchViewModels))
        {
            jobBranchViewModels = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Include(a => a.Job)
                .ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            MemoryCache.Set(nameof(GetAllJobsQuery), jobBranchViewModels, options: new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromDays(7),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7),
            });
        }
        
        return jobBranchViewModels!;
    }
}
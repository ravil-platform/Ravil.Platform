namespace Application.Features.Job.Queries.GetAllJobBranch;

public class GetAllJobBranchByFilterQueryHandler : IRequestHandler<GetAllJobBranchByFilterQuery, JobBranchFilter>
{
    protected JobBranchFilter JobBranchFilter { get; set; }
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobBranchByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchFilter>> Handle(GetAllJobBranchByFilterQuery request, CancellationToken cancellationToken)
    {
        JobBranchFilter = Mapper.Map<JobBranchFilter>(request);

        var jobBranchQuery = UnitOfWork.JobBranchRepository.TableNoTracking
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .AsQueryable();

        if (JobBranchFilter.CategoryId.HasValue)
        {
            var jobsId = await UnitOfWork.JobCategoryRepository.TableNoTracking
                .Where(j => j.CategoryId == request.CategoryId)
                .Select(a => a.JobId)
                .ToListAsync(cancellationToken: cancellationToken);

            if (jobsId.Any())
                jobBranchQuery = jobBranchQuery.Where(a => jobsId.Contains(a.JobId)).AsQueryable();
        }

        JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper);

        return await Task.FromResult(JobBranchFilter);
    }
}
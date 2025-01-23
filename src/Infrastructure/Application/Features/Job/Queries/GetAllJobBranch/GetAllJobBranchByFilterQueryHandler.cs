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
            .Include(a => a.Address).ThenInclude(a => a.Location);

        JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper);

        return await Task.FromResult(JobBranchFilter);
    }
}
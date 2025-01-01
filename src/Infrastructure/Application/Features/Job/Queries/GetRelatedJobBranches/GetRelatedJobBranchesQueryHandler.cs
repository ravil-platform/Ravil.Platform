namespace Application.Features.Job.Queries.GetRelatedJobBranches;

public class GetRelatedJobBranchesQueryHandler : IRequestHandler<GetRelatedJobBranchesQuery, JobBranchFilter>
{
    protected JobBranchFilter JobBranchFilter { get; set; }
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetRelatedJobBranchesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchFilter>> Handle(GetRelatedJobBranchesQuery request, CancellationToken cancellationToken)
    {
        JobBranchFilter = Mapper.Map<JobBranchFilter>(request);

        var query = await UnitOfWork.JobBranchRepository.GetJobRelatedJobBranches(request.CategoryId, request.CityId, request.Take);

        JobBranchFilter.Build(query.Count()).SetEntities(query, Mapper);

        return await Task.FromResult(JobBranchFilter);
    }
}
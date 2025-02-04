namespace Application.Features.Job.Queries.GetRelatedJobs;

public class GetRelatedJobsQueryHandler : IRequestHandler<GetRelatedJobsQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetRelatedJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetRelatedJobsQuery request, CancellationToken cancellationToken)
    {
        var jobBranches = await UnitOfWork.JobBranchRepository.GetRelatedJobBranches(request.JobId, request.Take);
        
        var result = Mapper.Map<List<JobBranchViewModel>>(jobBranches);

        return result;
    }
}
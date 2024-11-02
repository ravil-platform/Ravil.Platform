namespace Application.Features.Job.Queries.GetAllJobBranch;

public class GetAllJobBranchByFilterQueryHandler : IRequestHandler<GetAllJobBranchByFilterQuery, JobBranchFilter>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobBranchByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchFilter>> Handle(GetAllJobBranchByFilterQuery request, CancellationToken cancellationToken)
    {
        var jobBranchQuery = UnitOfWork.JobBranchRepository.TableNoTracking;

        request.JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper);

        return await Task.FromResult(request.JobBranchFilter);
    }
}
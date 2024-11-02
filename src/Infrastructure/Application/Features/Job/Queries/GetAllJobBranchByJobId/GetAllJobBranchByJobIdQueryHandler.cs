namespace Application.Features.Job.Queries.GetAllJobBranchByJobId;

public class GetAllJobBranchByJobIdQueryHandler : IRequestHandler<GetAllJobBranchByJobIdQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobBranchByJobIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAllJobBranchByJobIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.JobId == request.JobId);

        var jobBranchViewModel = Mapper.Map<List<JobBranchViewModel>>(result);

        return jobBranchViewModel;
    }
}
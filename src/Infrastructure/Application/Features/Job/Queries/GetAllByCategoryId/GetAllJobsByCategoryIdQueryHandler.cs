namespace Application.Features.Job.Queries.GetAllByCategoryId;

public class GetAllJobsByCategoryIdQueryHandler : IRequestHandler<GetAllJobsByCategoryIdQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllJobsByCategoryIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAllJobsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var jobBranches = await UnitOfWork.JobBranchRepository.GetJobBranchesByCategoryId(request.CategoryId, request.Take);
        
        var jobBranchesViewModel = Mapper.Map<List<JobBranchViewModel>>(jobBranches);

        return jobBranchesViewModel;
    }
}
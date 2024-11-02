namespace Application.Features.Job.Queries.GetJobBranchById;

public class GetJobBranchByIdQueryHandler : IRequestHandler<GetJobBranchByIdQuery, JobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetJobBranchByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }


    public async Task<Result<JobBranchViewModel>> Handle(GetJobBranchByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.Id);

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;
    }
}
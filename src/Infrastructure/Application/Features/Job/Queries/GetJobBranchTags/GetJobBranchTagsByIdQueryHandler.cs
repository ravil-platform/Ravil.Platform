namespace Application.Features.Job.Queries.GetJobBranchTags;

public class GetJobBranchTagsByIdQueryHandler : IRequestHandler<GetJobBranchTagsByIdQuery, List<JobBranchTagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobBranchTagsByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchTagViewModel>>> Handle(GetJobBranchTagsByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobBranchTagRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);

        var jobBranchTagViewModel = Mapper.Map<List<JobBranchTagViewModel>>(result);

        return jobBranchTagViewModel;
    }
}
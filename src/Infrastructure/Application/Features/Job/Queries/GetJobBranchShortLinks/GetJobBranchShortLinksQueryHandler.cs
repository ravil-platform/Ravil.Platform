namespace Application.Features.Job.Queries.GetJobBranchShortLinks;

public class GetJobBranchShortLinksQueryHandler : IRequestHandler<GetJobBranchShortLinksQuery,
    List<JobBranchShortLinkViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobBranchShortLinksQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchShortLinkViewModel>>> Handle(GetJobBranchShortLinksQuery request, CancellationToken cancellationToken)
    {
        var result =
            await UnitOfWork.JobBranchShortLinkRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);

        var jobBranchShortLinksViewModel = Mapper.Map<List<JobBranchShortLinkViewModel>>(result);

        return jobBranchShortLinksViewModel;
    }
}
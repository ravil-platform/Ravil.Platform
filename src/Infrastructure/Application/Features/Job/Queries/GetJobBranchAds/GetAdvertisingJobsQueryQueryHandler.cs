namespace Application.Features.Job.Queries.GetJobBranchAds;

public class GetAdvertisingJobsQueryQueryHandler : IRequestHandler<GetAdvertisingJobsQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAdvertisingJobsQueryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAdvertisingJobsQuery request, CancellationToken cancellationToken)
    {
        var jobBranches = await UnitOfWork.JobBranchAdsRepository.GetAllJobAds();

        var data = Mapper.Map<List<JobBranchViewModel>>(jobBranches);

        return data;
    }
}
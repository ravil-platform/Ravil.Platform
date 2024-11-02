namespace Application.Features.Job.Queries.GetBestJobs;

public class GetBestJobsQueryHandler : IRequestHandler<GetBestJobsQuery, List<JobViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetBestJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobViewModel>>> Handle(GetBestJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await UnitOfWork.JobRepository.GetBestJobs(request.Take);

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}
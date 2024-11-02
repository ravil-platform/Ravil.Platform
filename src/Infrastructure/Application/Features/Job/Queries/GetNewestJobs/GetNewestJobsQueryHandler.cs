namespace Application.Features.Job.Queries.GetNewestJobs;

public class GetNewestJobsQueryHandler : IRequestHandler<GetNewestJobsQuery, List<JobViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetNewestJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobViewModel>>> Handle(GetNewestJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await UnitOfWork.JobRepository.GetNewestJobs(request.Take);

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}
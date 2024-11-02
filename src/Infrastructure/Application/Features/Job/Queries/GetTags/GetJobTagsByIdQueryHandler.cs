namespace Application.Features.Job.Queries.GetTags;

public class GetJobTagsByIdQueryHandler : IRequestHandler<GetJobTagsByIdQuery, List<JobTagViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobTagsByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobTagViewModel>>> Handle(GetJobTagsByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobTagRepository.GetAllAsync(j => j.JobId == request.JobId);

        var jobTagViewModel = Mapper.Map<List<JobTagViewModel>>(result);

        return jobTagViewModel;
    }
}
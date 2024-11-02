namespace Application.Features.Job.Queries.GetByRoute;

public class GetJobByRouteQueryHandler : IRequestHandler<GetJobByRouteQuery, JobViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    public GetJobByRouteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<JobViewModel>> Handle(GetJobByRouteQuery request, CancellationToken cancellationToken)
    {
        var job = await UnitOfWork.JobRepository.GetByPredicate(j => j.Route == request.Route);

        if (job is null)
        {
            throw new NotFoundException();
        }

        var jobViewModel = Mapper.Map<JobViewModel>(job);

        return jobViewModel;
    }
}
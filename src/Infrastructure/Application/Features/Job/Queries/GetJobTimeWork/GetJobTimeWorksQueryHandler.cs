namespace Application.Features.Job.Queries.GetJobTimeWork;

public class GetJobTimeWorksQueryHandler : IRequestHandler<GetJobTimeWorksQuery, List<JobTimeWorkViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetJobTimeWorksQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobTimeWorkViewModel>>> Handle(GetJobTimeWorksQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobTimeWorkRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);

        var jobTimeWorkViewModels = Mapper.Map<List<JobTimeWorkViewModel>>(result);

        return jobTimeWorkViewModels;
    }
}
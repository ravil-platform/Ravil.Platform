namespace Application.Features.Job.Queries.GetAllJobBranchByJobId;

public class GetAllJobBranchByJobIdQueryHandler : IRequestHandler<GetAllJobBranchByJobIdQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobBranchByJobIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetAllJobBranchByJobIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobBranchRepository.TableNoTracking
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .Where(j => j.JobId == request.JobId)
            .ToListAsync(cancellationToken: cancellationToken);

        var jobBranchViewModel = Mapper.Map<List<JobBranchViewModel>>(result);

        return jobBranchViewModel;
    }
}
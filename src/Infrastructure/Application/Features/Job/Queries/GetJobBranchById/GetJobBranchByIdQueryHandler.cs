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
        var result = await UnitOfWork.JobBranchRepository.TableNoTracking.Include(a => a.JobTimeWorks)
            .Include(a => a.Address).ThenInclude(a => a.Location).Include(a => a.JobBranchGalleries)
            .Include(a => a.Job).ThenInclude(a => a.JobCategories).ThenInclude(a => a.Category)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value).Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .SingleOrDefaultAsync(current => current.Id.Equals(request.Id), cancellationToken: cancellationToken);

        if (result is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFoundException);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;
    }
}
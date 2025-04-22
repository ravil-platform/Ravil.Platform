namespace Application.Features.Job.Queries.GetJobBranchByRoute;

public class GetJobBranchByRouteQueryHandler : IRequestHandler<GetJobBranchByRouteQuery, JobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetJobBranchByRouteQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }


    public async Task<Result<JobBranchViewModel>> Handle(GetJobBranchByRouteQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.JobBranchRepository.TableNoTracking.Include(a => a.JobTimeWorks).Include(a => a.Address.City)
            .Include(a => a.Address).ThenInclude(a => a.Location).Include(a => a.JobBranchGalleries)
            .Include(a => a.Job).ThenInclude(a => a.JobCategories).ThenInclude(a => a.Category)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value).Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .FirstOrDefaultAsync(current => current.Route!.Equals(request.Route) || current.Title!.Equals(request.Route.SlugToText()), cancellationToken: cancellationToken);

        if (result is null)
        {
            return Result.Fail(Resources.Messages.Validations.NotFound);
        }

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(result);

        return jobBranchViewModel;
    }
}
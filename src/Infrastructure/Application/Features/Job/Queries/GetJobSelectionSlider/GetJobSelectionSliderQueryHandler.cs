namespace Application.Features.Job.Queries.GetJobSelectionSlider;

public class GetJobSelectionSliderQueryHandler : IRequestHandler<GetJobSelectionSliderQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobSelectionSliderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchViewModel>>> Handle(GetJobSelectionSliderQuery request, CancellationToken cancellationToken)
    {
        var fluentResult = new Result<List<JobBranchViewModel>>();

        ICollection<JobSelectionSlider> result = new List<JobSelectionSlider>();

        if (request.JobSliderType != null && request.JobId == null && request.JobBranchId == null)
        {
            if (request.Take == null)
            {
                result = await UnitOfWork.JobSelectionSliderRepository
                    .GetAllAsync(j => j.JobSliderType == request.JobSliderType);
            }
            else
            {
                result = await UnitOfWork.JobSelectionSliderRepository
                    .GetAllAsync(j => j.JobSliderType == request.JobSliderType, (int)request.Take);
            }

            var selectionSliderViewModel = Mapper.Map<List<JobSelectionSliderViewModel>>(result);
            var selectionJobBranchesId = selectionSliderViewModel.Select(s => s.JobBranchId);

            var jobBranchListResult = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Include(a => a.Job).Include(a => a.JobBranchGalleries)
                .Include(a => a.Job.JobCategories).ThenInclude(a => a.Category)
                .Include(a => a.Address).ThenInclude(a => a.Location)
                .Where(a => selectionJobBranchesId.Contains(a.Id))
                .Take(selectionSliderViewModel.Count)
                .ToListAsync(cancellationToken: cancellationToken);

            var jobBranchViewModel = Mapper.Map<List<JobBranchViewModel>>(jobBranchListResult);

            fluentResult.WithValue(jobBranchViewModel);
        }
        else if (request.JobSliderType == null && request.JobId != null && request.JobBranchId == null)
        {
            if (request.Take == null)
            {
                result = await UnitOfWork.JobSelectionSliderRepository.GetAllAsync(j => j.JobId == request.JobId);
            }
            else
            {
                result = await UnitOfWork.JobSelectionSliderRepository.GetAllAsync(j => j.JobId == request.JobId, (int)request.Take);
            }

            var selectionSliderViewModel = Mapper.Map<List<JobSelectionSliderViewModel>>(result);
            var selectionJobBranchesId = selectionSliderViewModel.Select(s => s.JobBranchId);

            var jobBranchListResult = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Include(a => a.Job).Include(a => a.JobBranchGalleries)
                .Include(a => a.Job.JobCategories).ThenInclude(a => a.Category)
                .Include(a => a.Address).ThenInclude(a => a.Location)
                .Where(a => selectionJobBranchesId.Contains(a.Id))
                .Take(selectionSliderViewModel.Count).ToListAsync(cancellationToken: cancellationToken);

            var jobBranchViewModel = Mapper.Map<List<JobBranchViewModel>>(jobBranchListResult);

            fluentResult.WithValue(jobBranchViewModel);
        }
        else if (request.JobSliderType == null && request.JobId == null && request.JobBranchId != null)
        {
            if (request.Take == null)
            {
                result = await UnitOfWork.JobSelectionSliderRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);
            }
            else
            {
                result = await UnitOfWork.JobSelectionSliderRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId, (int)request.Take);
            }

            var selectionSliderViewModel = Mapper.Map<List<JobSelectionSliderViewModel>>(result);
            var selectionJobBranchesId = selectionSliderViewModel.Select(s => s.JobBranchId);

            var jobBranchListResult = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Include(a => a.Job).Include(a => a.JobBranchGalleries)
                .Include(a => a.Job.JobCategories).ThenInclude(a => a.Category)
                .Include(a => a.Address).ThenInclude(a => a.Location)
                .Where(a => selectionJobBranchesId.Contains(a.Id))
                .Take(selectionSliderViewModel.Count).ToListAsync(cancellationToken: cancellationToken);

            var jobBranchViewModel = Mapper.Map<List<JobBranchViewModel>>(jobBranchListResult);

            fluentResult.WithValue(jobBranchViewModel);
        }

        return fluentResult;
    }
}
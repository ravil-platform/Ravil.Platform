namespace Application.Features.Job.Queries.GetJobSelectionSlider;

public class GetJobSelectionSliderQueryHandler : IRequestHandler<GetJobSelectionSliderQuery, List<JobSelectionSliderViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobSelectionSliderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobSelectionSliderViewModel>>> Handle(GetJobSelectionSliderQuery request, CancellationToken cancellationToken)
    {
        var fluentResult = new Result<List<JobSelectionSliderViewModel>>();

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

            fluentResult.WithValue(selectionSliderViewModel);
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

            fluentResult.WithValue(selectionSliderViewModel);
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

            fluentResult.WithValue(selectionSliderViewModel);
        }

        return fluentResult;
    }
}
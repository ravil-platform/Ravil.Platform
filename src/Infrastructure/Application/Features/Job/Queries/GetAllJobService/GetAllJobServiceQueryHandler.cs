namespace Application.Features.Job.Queries.GetAllJobService;

public class GetAllJobServiceQueryHandler : IRequestHandler<GetAllJobServiceQuery, List<JobServiceViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobServiceQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobServiceViewModel>>> Handle(GetAllJobServiceQuery request, CancellationToken cancellationToken)
    {
        var fluentResult = new Result<List<JobServiceViewModel>>();

        if (request.JobBranchId is not null)
        {
            var result =
                await UnitOfWork.JobServiceRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);

            var jobServiceViewModel = Mapper.Map<List<JobServiceViewModel>>(result);

            fluentResult.WithValue(jobServiceViewModel);

        }
        else if (request.ServiceId is not null)
        {
            var result =
                await UnitOfWork.JobServiceRepository.GetAllAsync(j => j.ServiceId == request.ServiceId);

            var jobServiceViewModel = Mapper.Map<List<JobServiceViewModel>>(result);

            fluentResult.WithValue(jobServiceViewModel);
        }
        else
        {
            var result =
                await UnitOfWork.JobServiceRepository.GetAllAsync();

            var jobServiceViewModel = Mapper.Map<List<JobServiceViewModel>>(result);

            fluentResult.WithValue(jobServiceViewModel);
        }


        return fluentResult;
    }
}
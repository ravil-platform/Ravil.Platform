namespace Application.Features.Job.Queries.GetJobBranchGalleries;

public class GetJobBranchGalleriesQueryHandler : IRequestHandler<GetJobBranchGalleriesQuery, List<JobBranchGalleryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetJobBranchGalleriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobBranchGalleryViewModel>>> Handle(GetJobBranchGalleriesQuery request, CancellationToken cancellationToken)
    {
        var result =
            await UnitOfWork.JobBranchGalleryRepository.GetAllAsync(j => j.JobBranchId == request.JobBranchId);

        var jobBranchGalleryViewModel = Mapper.Map<List<JobBranchGalleryViewModel>>(result);

        return jobBranchGalleryViewModel;
    }
}
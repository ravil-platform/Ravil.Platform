using Common.Utilities.Extensions;
using Constants.Files;

namespace Application.Features.Job.Commands.CreateJobBranch;

public class CreateJobBranchCommandHandler : IRequestHandler<CreateJobBranchCommand, JobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchViewModel>> Handle(CreateJobBranchCommand request, CancellationToken cancellationToken)
    {
        var jobBranch = Mapper.Map<JobBranch>(request);

        if (request.BranchVideo is not null)
        {
            var branchVideoName = request.BranchVideo.SaveFileAndReturnName(Paths.Job, TypeFile.Video);
            jobBranch.BranchVideo = branchVideoName;
        }

        if (request.LargePictureFile is not null)
        {
            var largePictureName = request.LargePictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);
            jobBranch.LargePicture = largePictureName;
        }

        if (request.SmallPictureFile is not null)
        {
            var smallPictureName = request.SmallPictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);
            jobBranch.SmallPicture = smallPictureName;
        }

        await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);
        await UnitOfWork.SaveAsync();

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(jobBranch);

        return jobBranchViewModel;
    }
}
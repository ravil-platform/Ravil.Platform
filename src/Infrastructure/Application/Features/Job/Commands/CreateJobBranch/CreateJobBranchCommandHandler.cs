namespace Application.Features.Job.Commands.CreateJobBranch;

public class CreateJobBranchCommandHandler : IRequestHandler<CreateJobBranchCommand, JobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IFtpService FtpService { get; }

    public CreateJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        FtpService = ftpService;
    }

    public async Task<Result<JobBranchViewModel>> Handle(CreateJobBranchCommand request, CancellationToken cancellationToken)
    {
        var jobBranch = Mapper.Map<JobBranch>(request);

        if (request.BranchVideo is not null)
        {
            var branchVideoName = await FtpService.UploadFileToFtpServer(request.BranchVideo, TypeFile.Video, Paths.Job, request.BranchVideo.FileName);

            //var branchVideoName = request.BranchVideo.SaveFileAndReturnName(Paths.Job, TypeFile.Video);

            jobBranch.BranchVideo = branchVideoName;
        }

        if (request.LargePictureFile is not null)
        {
            var largePictureName = await FtpService.UploadFileToFtpServer(request.LargePictureFile, TypeFile.Video, Paths.Job, request.LargePictureFile.FileName);

            //var largePictureName = request.LargePictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);

            jobBranch.LargePicture = largePictureName;
        }

        if (request.SmallPictureFile is not null)
        {
            var smallPictureName = await FtpService.UploadFileToFtpServer(request.SmallPictureFile, TypeFile.Video, Paths.Job, request.SmallPictureFile.FileName);

            //var smallPictureName = request.SmallPictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);

            jobBranch.SmallPicture = smallPictureName;
        }

        await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);
        await UnitOfWork.SaveAsync();

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(jobBranch);

        return jobBranchViewModel;
    }
}
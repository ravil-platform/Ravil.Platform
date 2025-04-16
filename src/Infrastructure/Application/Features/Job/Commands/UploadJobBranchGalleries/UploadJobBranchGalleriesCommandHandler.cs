namespace Application.Features.Job.Commands.UploadJobBranchGalleries;

public class UploadJobBranchGalleriesCommandHandler : IRequestHandler<UploadJobBranchGalleriesCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IFtpService FtpService { get; }

    public UploadJobBranchGalleriesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        FtpService = ftpService;
    }

    public async Task<Result> Handle(UploadJobBranchGalleriesCommand request, CancellationToken cancellationToken)
    {
        var result = new Result();

        var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);

        if (jobBranch is null)
        {
            throw new BadRequestException();
        }

        foreach (var item in request.Images)
        {
            //var imageName = item.SaveFileAndReturnName(Paths.JobBranchGalleryServer + request.JobBranchId, TypeFile.Image, null, null, null, jobBranch.SmallPicture);

            var imageName = await FtpService.UploadFileToFtpServer(item, TypeFile.Image, Paths.JobBranchGallery + request.JobBranchId, item.FileName, 777, null, null, null, jobBranch.SmallPicture);

            var gallery = new JobBranchGallery()
            {
                ImageName = imageName,
                JobBranchId = request.JobBranchId,
                Sort = 1,
            };

            await UnitOfWork.JobBranchGalleryRepository.InsertAsync(gallery);
        }

        jobBranch.LastUpdateDate = DateTime.Now;

        await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);

        await UnitOfWork.SaveAsync();

        result.WithSuccess(Resources.Messages.Successes.SuccessUploadFile);

        return result;
    }
}
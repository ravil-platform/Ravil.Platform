namespace Application.Features.Job.Commands.UploadJobBranchGalleries;

public class UploadJobBranchGalleriesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    : IRequestHandler<UploadJobBranchGalleriesCommand>
{
    #region ( Constructor )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;

    #endregion

    public async Task<Result> Handle(UploadJobBranchGalleriesCommand request, CancellationToken cancellationToken)
    {
        #region ( Upload JobBranch Galleries Command )

        var result = new Result();

        var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);
        if (jobBranch is null)
        {
            throw new BadRequestException();
        }

        foreach (var item in request.Images)
        {
            var imageName = await FtpService.UploadFileToFtpServer(item, TypeFile.Gallery, Paths.JobBranchGallery + request.JobBranchId, item.FileName, 777, null, null, null, jobBranch.SmallPicture);

            if (!string.IsNullOrWhiteSpace(imageName))
            {
                var gallery = new JobBranchGallery()
                {
                    ImageName = imageName,
                    JobBranchId = request.JobBranchId,
                    Sort = 1,
                };

                await UnitOfWork.JobBranchGalleryRepository.InsertAsync(gallery);
            }
        }

        jobBranch.LastUpdateDate = DateTime.Now;
        await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);

        await UnitOfWork.SaveAsync();

        result.WithSuccess(Resources.Messages.Successes.SuccessUploadFile);

        return result;

        #endregion
    }
}
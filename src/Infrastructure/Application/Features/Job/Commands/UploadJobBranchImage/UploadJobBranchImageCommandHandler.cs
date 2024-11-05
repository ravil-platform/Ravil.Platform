namespace Application.Features.Job.Commands.UploadJobBranchImage;

public class UploadJobBranchImageCommandHandler : IRequestHandler<UploadJobBranchImageCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public UploadJobBranchImageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UploadJobBranchImageCommand request, CancellationToken cancellationToken)
    {
        var result = new Result();

        var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);

        if (jobBranch is null)
        {
            throw new BadRequestException();
        }

        if (request.PhoneImage != null)
        {
            var phoneImageName = request.PhoneImage
                .SaveFileAndReturnName(Paths.JobBranchImageServer + request.JobBranchId, TypeFile.Image, null, null, null, jobBranch.SmallPicture);

            jobBranch.SmallPicture = phoneImageName;
        }

        if (request.DesktopImage != null)
        {
            var desktopImageName = request.DesktopImage
                .SaveFileAndReturnName(Paths.JobBranchImageServer + request.JobBranchId, TypeFile.Image, null, null, null, jobBranch.LargePicture);
            jobBranch.LargePicture = desktopImageName;
        }

        jobBranch.LastUpdateDate = DateTime.Now;

        await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
        await UnitOfWork.SaveAsync();

        result.WithSuccess(Resources.Messages.Successes.SuccessUploadFile);

        return result;
    }
}
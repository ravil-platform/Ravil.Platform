namespace Application.Features.Job.Commands.UploadJobBranchVideo;

public class UploadJobBranchVideoCommandHandler : IRequestHandler<UploadJobBranchVideoCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public UploadJobBranchVideoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UploadJobBranchVideoCommand request, CancellationToken cancellationToken)
    {
        var result = new Result();

        var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);

        if (jobBranch is null)
        {
            throw new BadRequestException();
        }

        var videoName = request.Video
            .SaveFileAndReturnName(Paths.JobBranchVideoServer + request.JobBranchId, TypeFile.Image, null, null, null, jobBranch.SmallPicture);

        jobBranch.BranchVideo = videoName;
        jobBranch.LastUpdateDate = DateTime.Now;

        await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
        await UnitOfWork.SaveAsync();

        result.WithSuccess(Resources.Messages.Successes.SuccessUploadFile);

        return result;
    }
}
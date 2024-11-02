namespace Application.Features.Job.Commands.Create;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, JobViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateJobCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobViewModel>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var largePictureName = request.LargePictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);
        var smallPictureName = request.SmallPictureFile.SaveFileAndReturnName(Paths.Job, TypeFile.Image);

        var job = Mapper.Map<Domain.Entities.Job.Job>(request);

        job.SocialMediaInfos = request.SocialMediaInfos.All(a => !string.IsNullOrWhiteSpace(a.SocialMediaLink))
            ? System.Text.Json.JsonSerializer.Serialize(request.SocialMediaInfos) : string.Empty;
        job.PhoneNumberInfos = request.PhoneNumberInfos.All(a => !string.IsNullOrWhiteSpace(a.PhoneNumber))
            ? System.Text.Json.JsonSerializer.Serialize(request.PhoneNumberInfos) : string.Empty;

        job.Route = !string.IsNullOrWhiteSpace(request.Route) ? request.Route : request.Title;
        job.Route = await UnitOfWork.ShortLinkRepository.EncodePersianLink(job.Route);

        job.LargePicture = largePictureName;
        job.SmallPicture = smallPictureName;

        await UnitOfWork.JobRepository.InsertAsync(job);
        await UnitOfWork.SaveAsync();

        var jobViewModel = Mapper.Map<JobViewModel>(job);

        return jobViewModel;
    }
}
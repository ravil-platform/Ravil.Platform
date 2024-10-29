namespace Application.Features.Job.Commands.CreateFreeJobBranch;

public class CreateFreeJobBranchCommandHandler : IRequestHandler<CreateFreeJobBranchCommand, JobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateFreeJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchViewModel>> Handle(CreateFreeJobBranchCommand request, CancellationToken cancellationToken)
    {
        await UnitOfWork.JobRepository.BeginTransactionAsync();

        #region ( Job )
        var job = Mapper.Map<Domain.Entities.Job.Job>(request.Job);

        job.SocialMediaInfos = request.Job.SocialMediaInfos.All(a => !string.IsNullOrWhiteSpace(a.SocialMediaLink))
            ? System.Text.Json.JsonSerializer.Serialize(request.Job.SocialMediaInfos) : string.Empty;
        job.PhoneNumberInfos = request.Job.PhoneNumberInfos.All(a => !string.IsNullOrWhiteSpace(a.PhoneNumber))
            ? System.Text.Json.JsonSerializer.Serialize(request.Job.PhoneNumberInfos) : string.Empty;

        job.Route = !string.IsNullOrWhiteSpace(request.Job.Route) ? request.Job.Route : request.Job.Title;
        job.Route = await UnitOfWork.ShortLinkRepository.EncodePersianLink(job.Route);

        job.SmallPicture = string.Empty;
        job.LargePicture = string.Empty;

        await UnitOfWork.JobRepository.InsertAsync(job);
        await UnitOfWork.SaveAsync();
        #endregion

        #region ( Job Categories )
        if (request.Categories.Length > 0)
        {
            foreach (var item in request.Categories)
            {
                await UnitOfWork.JobCategoryRepository.InsertAsync(new JobCategory()
                {
                    JobId = job.Id,
                    CategoryId = item
                });
            }
        }
        #endregion

        #region ( Job Branch )
        var jobBranch = Mapper.Map<JobBranch>(request.JobBranch);

        jobBranch.JobId = job.Id;

        await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);
        await UnitOfWork.SaveAsync();

        #region ( Tag, JobTimeWork, Service and JobBranchShortLink )
        #region ( JobBranchShortLink )
        string shortLink = await UnitOfWork.ShortLinkRepository.GenerateShortLink(5, ShortLinkType.JobBranch);

        await UnitOfWork.JobBranchShortLinkRepository.InsertAsync(new JobBranchShortLink
        {
            JobBranchId = jobBranch.Id,
            ShortKey = shortLink,
            Type = ShortLinkType.JobBranch
        });
        #endregion

        #region ( JobTimeWork )
        if (request.JobBranch.JobTimeWorkType.Equals(JobTimeWorkType.WorkSomeTime) && request.JobTimeWork.Count > 0)
        {
            foreach (var item in request.JobTimeWork)
            {
                if (item.StartTime != null && item.EndTime != null)
                {
                    await UnitOfWork.JobTimeWorkRepository.InsertAsync(new JobTimeWork()
                    {
                        DayOfWeekId = item.DayOfWeekId,
                        JobBranchId = jobBranch.Id,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime
                    });
                }
            }
        }
        #endregion

        #region ( JobBranchTag )
        if (request.Tags.Length > 0)
        {
            foreach (var item in request.Tags)
            {
                await UnitOfWork.JobBranchTagRepository.InsertAsync(new JobBranchTag
                {
                    JobBranchId = jobBranch.Id,
                    TagId = item
                });
            }
        }
        #endregion

        #region ( JobService )
        if (request.Services.Length > 0)
        {
            foreach (var item in request.Services)
            {
                await UnitOfWork.JobServiceRepository.InsertAsync(new JobService()
                {
                    JobBranchId = jobBranch.Id,
                    ServiceId = item
                });
            }
        }
        #endregion
        #endregion

        #region ( JobBranchGallery )
        if (request.JobBranch.Gallery is not null && request.JobBranch.Gallery.Any())
        {
            foreach (var image in request.JobBranch.Gallery)
            {
                var fileName = image!.SaveFileAndReturnName(Paths.JobBranchGallery + jobBranch.Id, TypeFile.Image);

                await UnitOfWork.JobBranchGalleryRepository
                    .InsertAsync(new JobBranchGallery() { ImageName = fileName, JobBranchId = jobBranch.Id });

                await UnitOfWork.SaveAsync();
            }
        }
        #endregion

        #region ( Job Branch Images )
        if (request.JobBranch.LargePictureFile is not null)
        {
            var largePictureName = request.Job.LargePictureFile.SaveFileAndReturnName(Paths.JobBranch + jobBranch.Id, TypeFile.Image);

            jobBranch.LargePicture = largePictureName;
        }

        if (request.JobBranch.SmallPictureFile is not null)
        {
            var smallPictureName = request.Job.SmallPictureFile.SaveFileAndReturnName(Paths.JobBranch + jobBranch.Id, TypeFile.Image);

            jobBranch.SmallPicture = smallPictureName;
        }

        if (request.JobBranch.BranchVideo is not null)
        {
            var branchVideoName = request.JobBranch.BranchVideo.SaveFileAndReturnName(Paths.JobBranchVideo + jobBranch.Id, TypeFile.Video);

            jobBranch.BranchVideo = branchVideoName;
        }

        await UnitOfWork.SaveAsync();
        #endregion

        #region ( Implement Location (Address) )
        var location = new Location
        {
            Lat = request.Lat,
            Long = request.Long,
            Route = request.Job.Route,
        };

        await UnitOfWork.LocationRepository.InsertAsync(location);
        await UnitOfWork.SaveAsync();

        var itemLocation = await UnitOfWork.LocationRepository.GetByIdAsync(location.Id);
        var address = new Address
        {
            JobBranchId = jobBranch.Id,
            LocationId = itemLocation!.Id,
            CityId = request.CityId,
            StateId = request.StateId,
            PostalCode = request.PostalCode,
            OtherAddress = request.FullAddress,
            PostalAddress = request.PostalAddress,
            Neighbourhood = request.Neighbourhood
        };

        await UnitOfWork.AddressRepository.InsertAsync(address);
        await UnitOfWork.SaveAsync();

        jobBranch.AddressId = address.Id;

        await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
        await UnitOfWork.SaveAsync();
        #endregion

        await UnitOfWork.JobRepository.CommitTransactionAsync();

        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(jobBranch);

        return jobBranchViewModel;
        #endregion
    }
}
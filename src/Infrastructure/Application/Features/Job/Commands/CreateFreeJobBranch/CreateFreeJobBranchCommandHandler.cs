using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Application.Features.Job.Commands.CreateFreeJobBranch;

public class CreateFreeJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    : IRequestHandler<CreateFreeJobBranchCommand, JobBranchViewModel>
{
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;


    public async Task<Result<JobBranchViewModel>> Handle(CreateFreeJobBranchCommand request, CancellationToken cancellationToken)
    {
        #region ( Create Free JobBranch Command )

        try
        {
            await UnitOfWork.JobRepository.BeginTransactionAsync();

            #region ( Job )
            var job = Mapper.Map<Domain.Entities.Job.Job>(request.Job);

            if (request.Job.SocialMediaInfos != null)
            {
                job.SocialMediaInfos = request.Job.SocialMediaInfos.All(a => !string.IsNullOrWhiteSpace(a.SocialMediaLink))
                    ? System.Text.Json.JsonSerializer.Serialize(request.Job.SocialMediaInfos) : string.Empty;
            }
            if (request.Job.PhoneNumberInfos != null)
            {
                job.PhoneNumberInfos = request.Job.PhoneNumberInfos.All(a => !string.IsNullOrWhiteSpace(a.PhoneNumber))
                    ? System.Text.Json.JsonSerializer.Serialize(request.Job.PhoneNumberInfos) : string.Empty;
            }

            job.Route = !string.IsNullOrWhiteSpace(request.Job.Route) ? request.Job.Route : request.Job.Title;
            job.Route = await UnitOfWork.ShortLinkRepository.EncodePersianLink(job.Route);

            job.SmallPicture = string.Empty;
            job.LargePicture = string.Empty;
            job.Content = request.FullAddress;

            await UnitOfWork.JobRepository.InsertAsync(job);
            await UnitOfWork.SaveAsync();
            #endregion

            #region ( Job Categories )
            if (request.Categories?.Length > 0)
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

            if (string.IsNullOrWhiteSpace(request.JobBranch.UserId))
            {
                if (HttpContextAccessor.HttpContext!.User.Identity is not null && HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    request.JobBranch.UserId = UserManager.GetUserId(HttpContextAccessor.HttpContext.User);
                }
            }

            var jobBranch = Mapper.Map<JobBranch>(request.JobBranch);

            jobBranch.JobId = job.Id;
            jobBranch.Description = request.FullAddress;
            jobBranch.JobTimeWorkType = JobTimeWorkType.WorkAllTime;

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

            if (request.JobTimeWork != null)
            {
                if (request.JobBranch.JobTimeWorkType.Equals(JobTimeWorkType.WorkSomeTime) && request.JobTimeWork.Count > 0)
                {
                    foreach (var item in request.JobTimeWork)
                    {
                        if (item is { StartTime: not null, EndTime: not null })
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
            }
            #endregion

            #region ( JobBranchTag )
            if (request.Tags is { Length: > 0 })
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
            if (request.Services is { Length: > 0 })
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
                    var fileName = image.SaveFileAndReturnName(Paths.JobBranchGallery + jobBranch.Id, TypeFile.Image);

                    await UnitOfWork.JobBranchGalleryRepository
                        .InsertAsync(new JobBranchGallery() { ImageName = fileName, JobBranchId = jobBranch.Id });

                    await UnitOfWork.SaveAsync();
                }
            }
            #endregion

            #region ( Job Branch Images )
            if (request.JobBranch.LargePictureFile is not null)
            {
                var largePictureName = request.JobBranch.LargePictureFile.SaveFileAndReturnName(Paths.JobBranch + jobBranch.Id, TypeFile.Image);

                jobBranch.LargePicture = largePictureName;
            }

            if (request.JobBranch.SmallPictureFile is not null)
            {
                var smallPictureName = request.JobBranch.SmallPictureFile.SaveFileAndReturnName(Paths.JobBranch + jobBranch.Id, TypeFile.Image);

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
            };

            await UnitOfWork.LocationRepository.InsertAsync(location);
            await UnitOfWork.SaveAsync();

            var itemLocation = await UnitOfWork.LocationRepository.GetByIdAsync(location.Id);
            var address = new Address
            {
                CityId = request.CityId,
                StateId = request.StateId,
                JobBranchId = jobBranch.Id,
                LocationId = itemLocation!.Id,
                OtherAddress = request.FullAddress,
                PostalCode = request.PostalCode ?? string.Empty,
                PostalAddress = request.PostalAddress ?? string.Empty,
                Neighbourhood = request.Neighbourhood ?? string.Empty
            };

            await UnitOfWork.AddressRepository.InsertAsync(address);
            await UnitOfWork.SaveAsync();

            jobBranch.AddressId = address.Id;

            await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
            await UnitOfWork.SaveAsync();
            #endregion

            #endregion

            await UnitOfWork.JobRepository.CommitTransactionAsync();

            var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(jobBranch);

            return jobBranchViewModel;
        }
        catch (Exception e)
        {
            await UnitOfWork.JobRepository.RollBackTransactionAsync();
            throw;
        }

        #endregion
    }
}
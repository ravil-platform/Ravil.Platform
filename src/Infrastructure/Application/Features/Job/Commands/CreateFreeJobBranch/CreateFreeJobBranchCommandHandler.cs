using System.Collections;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Features.Job.Commands.CreateFreeJobBranch;

public class CreateFreeJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender,
    IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IFtpService ftpService,
    Logging.Base.ILogger<CreateFreeJobBranchCommandHandler> logger)
    : IRequestHandler<CreateFreeJobBranchCommand, JobBranchViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<CreateFreeJobBranchCommandHandler> Logger { get; } = logger;

    #endregion

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
                var socialMediaInfos = JsonSerializer.Deserialize<List<SocialMediaInfosViewModel>>(request.Job.SocialMediaInfos.Replace(@"\", ""));
                job.SocialMediaInfos = socialMediaInfos is not null ? System.Text.Json.JsonSerializer.Serialize(socialMediaInfos) : string.Empty;
            }
            if (request.Job.PhoneNumberInfos != null)
            {
                var phoneNumberInfos = JsonSerializer.Deserialize<List<PhoneNumberInfosViewModel>>(request.Job.PhoneNumberInfos.Replace(@"\", ""));
                job.PhoneNumberInfos = phoneNumberInfos is not null ? System.Text.Json.JsonSerializer.Serialize(phoneNumberInfos) : string.Empty;
            }

            job.Route = !string.IsNullOrWhiteSpace(request.Job.Route) ? request.Job.Route : request.Job.Title;
            job.Route = await UnitOfWork.ShortLinkRepository.EncodePersianLink(job.Route);

            job.SmallPicture = string.Empty;
            job.LargePicture = string.Empty;
            job.Status = JobBranchStatus.WaitingToCheck;
            job.Content = request.Job.Content ?? request.FullAddress;

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

            if (string.IsNullOrWhiteSpace(request.JobBranch.UserId))
            {
                if (HttpContextAccessor.HttpContext!.User.Identity is not null && HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    request.JobBranch.UserId = UserManager.GetUserId(HttpContextAccessor.HttpContext.User);
                }
            }

            var jobBranch = Mapper.Map<JobBranch>(request.JobBranch);

            jobBranch.JobId = job.Id;
            jobBranch.Description = request.JobBranch.Description ?? request.FullAddress;
            jobBranch.JobTimeWorkType = request.JobBranch.JobTimeWorkType ?? JobTimeWorkType.WorkAllTime;

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

            if (request.JobTimeWork is { Length: > 0 })
            {
                var jobTimeWorks = JsonSerializer.Deserialize<List<JobTimeWorkViewModel>>(request.JobTimeWork);
                if (request.JobBranch.JobTimeWorkType.Equals(JobTimeWorkType.WorkSomeTime) && jobTimeWorks != null)
                {
                    foreach (var item in jobTimeWorks)
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
                    string originSavePath = string.Format("{0}{1}/", Paths.JobBranchGallery, jobBranch.Id);
                    var fileName = await FtpService.UploadFileToFtpServer(image, TypeFile.Image, originSavePath, image.FileName);

                    //var fileName = image.SaveFileAndReturnName(Paths.JobBranchGalleryServer + jobBranch.Id, TypeFile.Image);

                    await UnitOfWork.JobBranchGalleryRepository
                        .InsertAsync(new JobBranchGallery() { ImageName = fileName, JobBranchId = jobBranch.Id });

                    await UnitOfWork.SaveAsync();
                }
            }
            #endregion

            #region ( Job Branch Images )

            if (request.JobBranch.LargePictureFile is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranch, jobBranch.Id);
                var largePictureName = await FtpService.UploadFileToFtpServer(request.JobBranch.LargePictureFile, TypeFile.Image, originSavePath, request.JobBranch.LargePictureFile.FileName);

                //var largePictureName = request.JobBranch.LargePictureFile.SaveFileAndReturnName(Paths.JobBranchImageServer + jobBranch.Id, TypeFile.Image);

                jobBranch.LargePicture = largePictureName;
            }

            if (request.JobBranch.SmallPictureFile is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranch, jobBranch.Id);
                var smallPictureName = await FtpService.UploadFileToFtpServer(request.JobBranch.SmallPictureFile, TypeFile.Image, originSavePath, request.JobBranch.SmallPictureFile.FileName);

                //var smallPictureName = request.JobBranch.SmallPictureFile.SaveFileAndReturnName(Paths.JobBranchImageServer + jobBranch.Id, TypeFile.Image);

                jobBranch.SmallPicture = smallPictureName;
            }

            if (request.JobBranch.BranchVideo is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranchVideo, jobBranch.Id);
                var branchVideoName = await FtpService.UploadFileToFtpServer(request.JobBranch.BranchVideo, TypeFile.Video, originSavePath, request.JobBranch.BranchVideo.FileName);

                //var branchVideoName = request.JobBranch.BranchVideo.SaveFileAndReturnName(Paths.JobBranchVideoServer + jobBranch.Id, TypeFile.Video);

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

            #region ( Send Sms For User And Admin )

            if (!string.IsNullOrWhiteSpace(request.JobBranch.UserId))
            {
                var userInfo = await UnitOfWork.ApplicationUserRepository.GetByPredicate(u => u.Id.Equals(request.JobBranch.UserId));
                var number = await UnitOfWork.ConfigRepository.TableNoTracking.Select(c => c.OrderNotificationPhoneNumber).FirstAsync(cancellationToken);

                if (userInfo is not null && !string.IsNullOrWhiteSpace(number))
                {
                    var responseSms = await SmsSender.SendPattern(request.JobBranch.UserId, string.Empty, "addJobToAdmin");
                    if (!responseSms.Equals("ok"))
                    {
                        var parameters = new Hashtable
                        {
                            { nameof(request.JobBranch.UserId),  request.JobBranch.UserId},
                            { nameof(request.JobBranch.Title),  request.JobBranch.Title},
                            { nameof(userInfo.Firstname),  userInfo.Firstname},
                            { nameof(userInfo.Lastname),  userInfo.Lastname},
                            { nameof(number),  number}
                        };
                        Logger.LogError(message: "عملیات ارسال پیامک موفقیت آمیز نبود", parameters: parameters);
                    }
                }
            }

            #endregion

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
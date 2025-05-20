using System.Collections;
using AngleSharp.Common;
using Application.Features.GuideLine.Commands.GuideLineCompletion;
using PhoneNumberInfosViewModel = ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel;
using SocialMediaInfosViewModel = ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel;

namespace Application.Features.Job.Commands.UpdateBusiness;

public class UpdateBusinessCommandHandler(
    IMapper mapper,
    ISmsSender smsSender,
    IUnitOfWork unitOfWork,
    IFtpService ftpService,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<GuideLineCompletionCommandHandler> logger)
    : IRequestHandler<UpdateBusinessCommand, JobBranchViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<GuideLineCompletionCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<JobBranchViewModel>> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        #region ( Update Business Data Command )

        try
        {
            await UnitOfWork.JobRepository.BeginTransactionAsync();

            var itemJobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId!);
            if (itemJobBranch is null)
            {
                throw new BadRequestException();
            }

            #region ( Job )

            if (request.SocialMediaInfos != null)
            {
                var socialMediaInfos = System.Text.Json.JsonSerializer.Deserialize<List<SocialMediaInfosViewModel>>(request.SocialMediaInfos);
                itemJobBranch.Job.SocialMediaInfos = socialMediaInfos is not null ? System.Text.Json.JsonSerializer.Serialize(socialMediaInfos) : string.Empty;
            }
            if (request.PhoneNumberInfos != null)
            {
                var phoneNumberInfos = System.Text.Json.JsonSerializer.Deserialize<List<PhoneNumberInfosViewModel>>(request.PhoneNumberInfos);
                itemJobBranch.Job.PhoneNumberInfos = phoneNumberInfos is not null ? System.Text.Json.JsonSerializer.Serialize(phoneNumberInfos) : string.Empty;
            }

            if (request.IsEndWork.HasValue)
            {
                itemJobBranch.Job.Status = JobBranchStatus.EndWork;
            }
            itemJobBranch.Job.Content = request.Description ?? request.Summary ?? request.FullAddress;

            #endregion

            #region ( Job Keywords )

            if (request.Keywords is { Length: > 0 })
            {
                #region ( Remove Current Keywords )

                var currentKeywords = await UnitOfWork.JobKeywordRepository
                    .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

                if (currentKeywords.Any())
                {
                    UnitOfWork.JobKeywordRepository.RemoveRange(currentKeywords.AsEnumerable());
                }

                #endregion

                foreach (var item in request.Keywords)
                {
                    await UnitOfWork.JobKeywordRepository.InsertAsync(new JobKeyword
                    {
                        JobBranchId = itemJobBranch.Id,
                        KeywordId = item,
                    });
                }
            }

            #endregion

            #region ( Job Branch )

            #region ( JobBranch ShortLink )

            var jobBranchHasShortLink = await UnitOfWork.JobBranchShortLinkRepository.TableNoTracking
                .AnyAsync(a => a.JobBranchId.Equals(request.JobBranchId), cancellationToken: cancellationToken);

            if (!jobBranchHasShortLink)
            {
                string shortLink = await UnitOfWork.ShortLinkRepository.GenerateShortLink(5, ShortLinkType.JobBranch);

                await UnitOfWork.JobBranchShortLinkRepository.InsertAsync(new JobBranchShortLink
                {
                    JobBranchId = itemJobBranch.Id,
                    ShortKey = shortLink,
                    Type = ShortLinkType.JobBranch
                });
            }
            #endregion

            #region ( JobTimeWorks )

            if (request.JobTimeWorks is { Length: > 0 })
            {
                #region ( Remove Current JobTimeWork )

                var currentTimeWorks = await UnitOfWork.JobTimeWorkRepository
                    .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

                if (currentTimeWorks.Any())
                {
                    UnitOfWork.JobTimeWorkRepository.RemoveRange(currentTimeWorks.AsEnumerable());
                }

                #endregion

                var jobTimeWorks = System.Text.Json.JsonSerializer.Deserialize<List<JobTimeWorkViewModel>>(request.JobTimeWorks);

                if (itemJobBranch.JobTimeWorkType.Equals(JobTimeWorkType.WorkSomeTime) && jobTimeWorks != null)
                {
                    foreach (var item in jobTimeWorks)
                    {
                        if (item is { StartTime: not null, EndTime: not null })
                        {
                            await UnitOfWork.JobTimeWorkRepository.InsertAsync(new JobTimeWork
                            {
                                DayOfWeekId = item.DayOfWeekId,
                                JobBranchId = itemJobBranch.Id,
                                StartTime = item.StartTime,
                                EndTime = item.EndTime
                            });
                        }
                    }
                }
            }
            #endregion

            #region ( JobBranch Gallery )

            if (request.Gallery is not null && request.Gallery.Any())
            {
                foreach (var image in request.Gallery)
                {
                    string originSavePath = string.Format("{0}{1}/", Paths.JobBranchGallery, itemJobBranch.Id);
                    var fileName = await FtpService.UploadFileToFtpServer(image, TypeFile.Gallery, originSavePath, image.FileName);

                    //var fileName = image.SaveFileAndReturnName(Paths.JobBranchGalleryServer + jobBranch.Id, TypeFile.Image);

                    await UnitOfWork.JobBranchGalleryRepository
                        .InsertAsync(new JobBranchGallery() { ImageName = fileName, JobBranchId = itemJobBranch.Id });

                    await UnitOfWork.SaveAsync();
                }
            }
            #endregion

            #region ( JobBranch Images And Video )

            if (request.LargePictureFile is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranch, itemJobBranch.Id);

                #region ( Remove Current Picture )

                if (!string.IsNullOrWhiteSpace(itemJobBranch.LargePicture))
                {
                    var response = await FtpService.DeleteFileToFtpServer(originSavePath, itemJobBranch.LargePicture);
                    if (!response)
                    {
                        Logger.LogError(null, "LargePicture DeleteFileToFtpServer is Error",
                            new Hashtable
                            {
                                { "originSavePath", originSavePath },
                                { "deleteFileName", itemJobBranch.LargePicture },
                                { "thumbSavePath", null }
                            });
                    }
                }

                #endregion

                var largePictureName = await FtpService.UploadFileToFtpServer(request.LargePictureFile, TypeFile.Image, originSavePath, request.LargePictureFile.FileName);
                itemJobBranch.LargePicture = largePictureName;
            }

            if (request.SmallPictureFile is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranch, itemJobBranch.Id);

                #region ( Remove Current Picture )

                if (!string.IsNullOrWhiteSpace(itemJobBranch.SmallPicture))
                {
                    var response = await FtpService.DeleteFileToFtpServer(originSavePath, itemJobBranch.SmallPicture);
                    if (!response)
                    {
                        Logger.LogError(null, "SmallPicture DeleteFileToFtpServer is Error",
                            new Hashtable
                            {
                                { "originSavePath", originSavePath },
                                { "deleteFileName", itemJobBranch.LargePicture },
                                { "thumbSavePath", null }
                            });
                    }
                }

                #endregion

                var smallPictureName = await FtpService.UploadFileToFtpServer(request.SmallPictureFile, TypeFile.Image, originSavePath, request.SmallPictureFile.FileName);
                itemJobBranch.SmallPicture = smallPictureName;
            }

            if (request.BranchVideo is not null)
            {
                string originSavePath = string.Format("{0}{1}/", Paths.JobBranchVideo, itemJobBranch.Id);

                #region ( Remove Current Video )

                if (!string.IsNullOrWhiteSpace(itemJobBranch.BranchVideo))
                {
                    var response = await FtpService.DeleteFileToFtpServer(originSavePath, itemJobBranch.BranchVideo);
                    if (!response)
                    {
                        Logger.LogError(null, "BranchVideo DeleteFileToFtpServer is Error",
                            new Hashtable
                            {
                                { "originSavePath", originSavePath },
                                { "deleteFileName", itemJobBranch.LargePicture },
                                { "thumbSavePath", null }
                            });
                    }
                }

                #endregion

                var branchVideoName = await FtpService.UploadFileToFtpServer(request.BranchVideo, TypeFile.Video, originSavePath, request.BranchVideo.FileName);
                itemJobBranch.BranchVideo = branchVideoName;
            }

            if (request.LargePictureFile is not null
                || request.SmallPictureFile is not null
                || request.BranchVideo is not null)
            {
                await UnitOfWork.SaveAsync();
            }

            #endregion

            #region ( Update Address (Location) )

            var jobBranchAddress = await UnitOfWork.AddressRepository.GetByIdAsync(itemJobBranch.AddressId!);
            if (jobBranchAddress is not null)
            {
                var updateAddress = Mapper.Map(request, jobBranchAddress);

                await UnitOfWork.AddressRepository.UpdateAsync(updateAddress);
                await UnitOfWork.SaveAsync();
            }

            #endregion

            itemJobBranch.LastUpdateDate = DateTime.Now;
            itemJobBranch.JobTimeWorkType = JobTimeWorkType.WorkSomeTime;

            await UnitOfWork.JobBranchRepository.UpdateAsync(itemJobBranch);
            await UnitOfWork.SaveAsync();

            #endregion

            await UnitOfWork.JobRepository.CommitTransactionAsync();

            var result = Mapper.Map<JobBranchViewModel>(itemJobBranch);
            return result;
        }
        catch (Exception e)
        {
            await UnitOfWork.JobRepository.RollBackTransactionAsync();
            Logger.LogError(message: e.InnerException?.Message ?? e.Message, parameters: new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
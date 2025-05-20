using System.Collections;
using AngleSharp.Common;
using ViewModels.QueriesResponseViewModel.Job.GuideLines;
using JsonSerializer = System.Text.Json.JsonSerializer;
using PhoneNumberInfosViewModel = ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel;
using SocialMediaInfosViewModel = ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel;

namespace Application.Features.GuideLine.Commands.GuideLineCompletion;

public class GuideLineCompletionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISmsSender smsSender,
    IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IFtpService ftpService,
    Logging.Base.ILogger<GuideLineCompletionCommandHandler> logger)
    : IRequestHandler<GuideLineCompletionCommand, GuideLineCompletionViewModel>
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

    public async Task<Result<GuideLineCompletionViewModel>> Handle(GuideLineCompletionCommand request, CancellationToken cancellationToken)
    {
        #region ( GuideLine Completion Command )

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var itemJobBranch = await UnitOfWork.JobBranchRepository.Table.Include(a => a.JobKeywords).Include(a => a.JobTimeWorks)
                .Include(a => a.Address).ThenInclude(a => a.Location).Include(a => a.JobBranchGalleries)
                .Include(a => a.Job).ThenInclude(a => a.JobCategories).ThenInclude(a => a.Category)
                .SingleOrDefaultAsync(a => a.Id == request.JobBranchId!, cancellationToken: cancellationToken);

            if (itemJobBranch is null)
                throw new BadRequestException();

            var guideLineCompletion = Mapper.Map<GuideLineCompletionViewModel>(itemJobBranch);

            #region ( Job GuideLines )

            #region ( GuideLine SocialMediaInfos )

            if (request.SocialMediaInfos != null)
            {
                var socialMediaInfos = JsonSerializer.Deserialize<List<SocialMediaInfosViewModel>>(request.SocialMediaInfos);
                itemJobBranch.Job.SocialMediaInfos = socialMediaInfos is not null ? JsonSerializer.Serialize(socialMediaInfos) : string.Empty;

                await UnitOfWork.JobBranchRepository.AttachAsync(itemJobBranch);
                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedSocialMediaInfos = true;
                }
            }

            #endregion

            #region ( GuideLine PhoneNumberInfos )

            if (request.PhoneNumberInfos != null)
            {
                var phoneNumberInfos = JsonSerializer.Deserialize<List<PhoneNumberInfosViewModel>>(request.PhoneNumberInfos);
                itemJobBranch.Job.PhoneNumberInfos = phoneNumberInfos is not null ? JsonSerializer.Serialize(phoneNumberInfos) : string.Empty;

                await UnitOfWork.JobBranchRepository.AttachAsync(itemJobBranch);
                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedPhoneNumberInfos = true;
                }
            }

            #endregion

            #region ( GuideLine Description )

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                itemJobBranch.Job.Content = request.Description;
                itemJobBranch.BranchContent = request.Description;

                await UnitOfWork.JobBranchRepository.AttachAsync(itemJobBranch);
                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedDescription = true;
                }
            }

            #endregion

            #region ( GuideLine Summary )

            if (!string.IsNullOrWhiteSpace(request.Summary))
            {
                itemJobBranch.Description = request.Summary;

                await UnitOfWork.JobBranchRepository.AttachAsync(itemJobBranch);
                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedSummary = true;
                }
            }

            #endregion

            #region ( GuideLine Title )

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                itemJobBranch.Title = request.Title;
                itemJobBranch.Job.Title = request.Title;

                await UnitOfWork.JobBranchRepository.AttachAsync(itemJobBranch);
                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedTitle = true;
                }
            }

            #endregion

            #endregion

            #region ( Job Branch GuideLines )

            #region ( GuideLine Job Keywords )

            if (request.Keywords is { Length: > 0 })
            {
                var currentKeywords = await UnitOfWork.JobKeywordRepository
                    .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

                if (currentKeywords.Any())
                {
                    UnitOfWork.JobKeywordRepository.RemoveRange(currentKeywords.AsEnumerable());
                }

                foreach (var item in request.Keywords)
                {
                    await UnitOfWork.JobKeywordRepository.InsertAsync(new JobKeyword
                    {
                        JobBranchId = itemJobBranch.Id,
                        KeywordId = item,
                    });
                }

                var saveChangesRes = await UnitOfWork.SaveAsync();

                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedKeywords = true;
                }
            }

            #endregion

            #region ( GuideLine JobBranch Gallery )

            if (request.Gallery is not null && request.Gallery.Any())
            {
                foreach (var image in request.Gallery)
                {
                    string originSavePath = string.Format("{0}{1}/", Paths.JobBranchGallery, itemJobBranch.Id);
                    var fileName = await FtpService.UploadFileToFtpServer(image, TypeFile.Gallery, originSavePath, image.FileName);

                    await UnitOfWork.JobBranchGalleryRepository
                        .InsertAsync(new JobBranchGallery() { ImageName = fileName, JobBranchId = itemJobBranch.Id });
                }

                var saveChangesRes = await UnitOfWork.SaveAsync();
                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedGalleryAndImages = true;
                }
            }
            #endregion

            #region ( GuideLine JobBranch Images And Video )

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
                var saveChangesRes = await UnitOfWork.SaveAsync();
                if (saveChangesRes > 0)
                {
                    guideLineCompletion.IsCompletedGalleryAndImages = true;
                }
            }

            #endregion

            #region ( GuideLine Address (Location) )

            var jobBranchAddress = await UnitOfWork.AddressRepository.Table.Include(a => a.Location)
                .SingleOrDefaultAsync(a => a.Id == itemJobBranch.AddressId!, cancellationToken: cancellationToken);

            if (jobBranchAddress is not null)
            {
                if (request is { Lat: > 0, Long: > 0})
                {
                    var updateAddress = Mapper.Map(request, jobBranchAddress);
                    updateAddress.Location.Lat = request.Lat.Value;
                    updateAddress.Location.Long = request.Long.Value;

                    await UnitOfWork.AddressRepository.AttachAsync(updateAddress);

                    var saveChangesRes = await UnitOfWork.SaveAsync();
                    if (saveChangesRes > 0)
                    {
                        guideLineCompletion.IsCompletedAddress = true;
                    }
                }
            }

            #endregion

            #region ( GuideLine Save Changes Async )

            itemJobBranch.LastUpdateDate = DateTime.UtcNow;
            itemJobBranch.JobTimeWorkType = JobTimeWorkType.WorkSomeTime;

            await UnitOfWork.JobBranchRepository.UpdateAsync(itemJobBranch);
            await UnitOfWork.SaveAsync();

            #endregion

            #endregion

            #region ( Commit Transaction Async )

            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

            #endregion

            #region ( Calculate GuideLine Completion )

            guideLineCompletion.TotalStepCount = 8;

            if (guideLineCompletion.IsCompletedTitle)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedAddress)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedSummary)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedDescription)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedGalleryAndImages)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedKeywords)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedSocialMediaInfos)
                guideLineCompletion.CompletedStepCount += 1;

            if (guideLineCompletion.IsCompletedPhoneNumberInfos)
                guideLineCompletion.CompletedStepCount += 1;

            #endregion

            return guideLineCompletion;
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            Logger.LogError(message: e.InnerException?.Message ?? e.Message, parameters: new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
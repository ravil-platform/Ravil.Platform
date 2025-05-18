using System.Collections;
using AngleSharp.Common;
using ViewModels.QueriesResponseViewModel.Job.GuideLines;

namespace Application.Features.GuideLine.Queries.GetGuideLines;

public class GetGuideLinesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetGuideLinesQueryHandler> logger)
    : IRequestHandler<GetGuideLinesQuery, GuideLineCompletionViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected Logging.Base.ILogger<GetGuideLinesQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<GuideLineCompletionViewModel>> Handle(GetGuideLinesQuery request, CancellationToken cancellationToken)
    {
        #region ( Get GuideLines Completion Query )

        try
        {
            var result = new Result<GuideLineCompletionViewModel>();

            var jobBranch = await UnitOfWork.JobBranchRepository.TableNoTracking.Include(a => a.JobKeywords).Include(a => a.JobTimeWorks)
                .Include(a => a.Address).ThenInclude(a => a.Location).Include(a => a.JobBranchGalleries)
                .Include(a => a.Job).ThenInclude(a => a.JobCategories).ThenInclude(a => a.Category)
                .Where(current => current.JobId.Equals(request.JobId) && current.UserId!.Equals(request.UserId))
                .Where(a => a.Job.Status == JobBranchStatus.Accepted || a.Status == JobBranchStatus.Accepted)
                .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (jobBranch is null)
            {
                return result.WithError(Resources.Messages.Validations.NotFoundException);
            }

            #region ( Calc GuideLine Completion )

            var guideLineCompletion = new GuideLineCompletionViewModel();
            guideLineCompletion.Business = Mapper.Map<JobBranchViewModel>(jobBranch);
            guideLineCompletion.TotalStepCount = 8;

            guideLineCompletion.IsCompletedTitle = !string.IsNullOrWhiteSpace(jobBranch.Title);
            guideLineCompletion.IsCompletedAddress = jobBranch.Address is not null && !string.IsNullOrWhiteSpace(jobBranch.Address.OtherAddress) && jobBranch.Address.Location is { Lat: > 0, Long: > 0 };
            guideLineCompletion.IsCompletedSummary = !string.IsNullOrWhiteSpace(jobBranch.Job.Summary);
            guideLineCompletion.IsCompletedDescription = !string.IsNullOrWhiteSpace(jobBranch.Description);
            guideLineCompletion.IsCompletedGalleryAndImages = jobBranch.JobBranchGalleries is not null;
            guideLineCompletion.IsCompletedKeywords = jobBranch.JobKeywords.Any();
            guideLineCompletion.IsCompletedSocialMediaInfos = !string.IsNullOrWhiteSpace(jobBranch.Job.SocialMediaInfos);
            guideLineCompletion.IsCompletedPhoneNumberInfos = !string.IsNullOrWhiteSpace(jobBranch.Job.PhoneNumberInfos);

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

            result.WithValue(guideLineCompletion);

            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            throw;
        }

        #endregion
    }
}
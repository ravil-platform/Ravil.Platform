using System.Collections;
using AngleSharp.Common;
using Domain.Entities.Histories.Enums;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetTagsPotential;

public class GetTagsPotentialQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetTagsPotentialQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetTagsPotentialQuery, List<TagsPotentialViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetTagsPotentialQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<TagsPotentialViewModel>>> Handle(GetTagsPotentialQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Tags Potential Query )

        var result = new Result<List<TagsPotentialViewModel>>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            #endregion

            var businessKeywords = await UnitOfWork.JobKeywordRepository.TableNoTracking
                .Include(a => a.Keyword)
                .Where(a => a.JobBranchId == request.JobBranchId)
                .Select(a => a.Keyword).Take(2).Distinct()
                .ToListAsync(cancellationToken: cancellationToken);

            var latestWeekJobsAction = await UnitOfWork.ActionHistoriesRepository.TableNoTracking
                .Where(a => a.Time.Day <= DateTime.UtcNow.Day && a.Time.Day >= DateTime.UtcNow.AddDays(-14).Day)
                .Where(a => a.JobId == request.JobId.ToString() && a.ActionType == ActionType.JobPageView.ToString())
                .Where(a => businessKeywords.Select(s => s.Slug).Contains(a.PageSlug) && a.JobIsActiveAds.HasValue && a.JobIsActiveAds.Value)
                .ToListAsync(cancellationToken: cancellationToken);

            var tagsPotential = new List<TagsPotentialViewModel>();
            foreach (var item in businessKeywords)
            {
                tagsPotential.Add(new TagsPotentialViewModel
                {
                    Tag = Mapper.Map<JobTagsViewModel>(item),
                    ActualView = latestWeekJobsAction.Count(a => a.JobIsActiveAds.HasValue && a.JobIsActiveAds.Value),
                    PotentialView = latestWeekJobsAction.Count(a => a.JobIsActiveAds.HasValue && !a.JobIsActiveAds.Value),
                });
            }

            result.WithValue(tagsPotential);
            return result;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}
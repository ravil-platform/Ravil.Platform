using System.Collections;
using System.Net;
using AngleSharp.Common;
using Domain.Entities.Histories.Enums;
using Resources.Messages;

namespace Application.Features.Job.Queries.GetJobRankingsByFilter;

public class GetJobRankingsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetJobRankingsByFilterQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GetJobRankingsByFilterQuery, List<JobRankingViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetJobRankingsByFilterQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<List<JobRankingViewModel>>> Handle(GetJobRankingsByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job Rankings By Filter Query )

        var result = new Result<List<JobRankingViewModel>>();

        try
        {
            #region ( Validations )

            if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
            {
                return Result.Fail(Validations.BadRequestException);
            }

            #region ( BusinessOwner )

            /*var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
            var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);*/

            #endregion

            #endregion

            var query = UnitOfWork.JobRankingHistoryRepository.TableNoTracking
                .Where(a => a.JobId == request.JobId)
                .AsQueryable();

            var queryAction = UnitOfWork.ActionHistoriesRepository.TableNoTracking
                .Where(a => a.JobId == request.JobId.ToString()
                    && (a.ActionType == ActionType.ClickOnChat.ToString() 
                    || a.ActionType == ActionType.ClickOnImages.ToString()
                    || a.ActionType == ActionType.ClickOnWebSite.ToString()
                    || a.ActionType == ActionType.ClickOnMap.ToString()
                    || a.ActionType == ActionType.ClickOnCall.ToString()
                    || a.ActionType == ActionType.ClickOnCard.ToString()
                    || a.ActionType == ActionType.JobPageView.ToString()))
                .AsQueryable();

            if (request is { FromDate: not null, ToDate: not null })
            {
                var fromDate = DateTimeOffset.FromUnixTimeSeconds(request.FromDate.Value);
                var toDate = DateTimeOffset.FromUnixTimeSeconds(request.ToDate.Value);

                query = query.Where(a => a.CreateAt.Day >= fromDate.Day && a.CreateAt.Day <= toDate.Day);
                queryAction = queryAction.Where(a => a.Time.Day >= fromDate.Day && a.Time.Day <= toDate.Day);
            }
            else
            {
                query = query.Where(a => a.CreateAt.Day <= DateTime.UtcNow.Day && a.CreateAt.Day >= DateTime.UtcNow.AddDays(-14).Day);
                queryAction = queryAction.Where(a => a.Time.Day <= DateTime.UtcNow.Day && a.Time.Day >= DateTime.UtcNow.AddDays(-14).Day);
            }
            
            var jobRankingHistories = await query.OrderBy(a => a.CreateAt)
                .ToListAsync(cancellationToken: cancellationToken);
            
            var latestWeekJobsAction = await queryAction.OrderBy(a => a.Time)
                .ToListAsync(cancellationToken: cancellationToken);

            var jobRankingsViewModels = new List<JobRankingViewModel>();
            jobRankingsViewModels.AddRange(jobRankingHistories.GroupBy(a => a.PageUrl)
            .Select(group => new JobRankingViewModel
            {
                PageUrl = WebUtility.UrlDecode(group.Key),
                AveragePosition = Convert.ToDouble(jobRankingHistories.Where(a => a.PageUrl.Equals(group.Key)).Sum(a => a.Position) / jobRankingHistories.Count(a => a.PageUrl.Equals(group.Key))),
                ClickCount = latestWeekJobsAction?.Count(a => a.PageUrl == group.Key) ?? 0
            }).ToList());


            result.WithValue(jobRankingsViewModels);
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
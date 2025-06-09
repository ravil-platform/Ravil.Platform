using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using Domain.Entities.Histories.Enums;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.ActionHistories.Create;

public class CreateActionHistoriesCommandHandler(IUnitOfWork unitOfWork,
    IDistributedCache distributedCache, IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<CreateActionHistoriesCommandHandler> logger)
: IRequestHandler<CreateActionHistoriesCommand>
{
    #region ( Dependencies )

    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected Logging.Base.ILogger<CreateActionHistoriesCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result> Handle(CreateActionHistoriesCommand request, CancellationToken cancellationToken)
    {
        #region ( Create Action Histories Command )

        var result = new Result();
        var userIp = HttpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

        #region ( Validations )

        if (request.Data.Any(a => !a.ActionType.HasValue 
            || string.IsNullOrWhiteSpace(a.PageUrl)
            || string.IsNullOrWhiteSpace(a.PageSlug)
            || string.IsNullOrWhiteSpace(a.PageTitle)))
        {
            Logger.LogError(exception: null, Resources.Messages.Validations.BadRequestException, new Hashtable(request.ToDictionary()));

            return result.WithError(Resources.Messages.Validations.BadRequestException);
        }

        #endregion

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            foreach (var itemAction in request.Data)
            {
                var job = await UnitOfWork.JobRepository.GetByPredicate(j => j.Id == itemAction.JobId);
                if (job != null)
                {
                    var actionHistory = new Domain.Entities.Histories.ActionHistories();
                    actionHistory.AddressIp = userIp ?? IpAddresses.Local;
                    actionHistory.JobId = job.Id.ToString();
                    actionHistory.JobTitle = job.Title;

                    if (itemAction.CategoryId.HasValue || string.IsNullOrWhiteSpace(itemAction.CategoryName))
                    {
                        var category = await UnitOfWork.JobCategoryRepository.GetByPredicate(j => j.JobId == job.Id, nameof(Category));
                        if (category != null)
                        {
                            actionHistory.CategoryId = category.CategoryId;
                            actionHistory.CategoryName = category.Category.Name;
                        }
                    }

                    actionHistory.Location = itemAction.Location;
                    actionHistory.Time = DateTime.UtcNow;

                    if (!string.IsNullOrWhiteSpace(itemAction.UserId))
                    {
                        var user = await UnitOfWork.ApplicationUserRepository.GetByPredicate(j => j.Id.Equals(itemAction.UserId));

                        if (user is not null)
                        {
                            actionHistory.UserId = user.Id;
                            actionHistory.FullName = user.UserName;
                        }
                    }

                    if (itemAction.ActionType is >= ActionType.ClickOnChat and <= ActionType.JobPageView or ActionType.ViewListingPageAction)
                    {
                        actionHistory.JobIsActiveAds = itemAction.IsActiveAds;
                    }

                    actionHistory.PageUrl = WebUtility.UrlDecode(itemAction.PageUrl);
                    actionHistory.PageSlug = WebUtility.UrlDecode(itemAction.PageSlug);
                    actionHistory.PageTitle = WebUtility.UrlDecode(itemAction.PageTitle);
                    actionHistory.ActionType = itemAction.ActionType!.Value.GetEnumDisplayName()!;

                    await UnitOfWork.ActionHistoriesRepository.InsertAsync(actionHistory);

                    #region ( Handle JobInfo )

                    var jobInfo = new JobInfo
                    {
                        Visit = 0,
                        ClickOnCard = 0,
                        ClickOnCall = 0,
                        ClickOnMap = 0,
                        ClickOnChat = 0,
                        ClickOnImages = 0,
                        ClickOnWebSite = 0,
                        AverageClickOnCall = 0,
                        JobId = itemAction.JobId,
                        CreateAt = DateTime.UtcNow,
                        IsActiveAds = itemAction.IsActiveAds ?? false,
                    };

                    switch (itemAction.ActionType)
                    {
                        case ActionType.ViewListingPageAction:
                            jobInfo.Visit = 1;
                            break;
                        case ActionType.ClickOnChat:
                            jobInfo.ClickOnChat = 1;
                            break;
                        case ActionType.ClickOnImages:
                            jobInfo.ClickOnImages = 1;
                            break;
                        case ActionType.ClickOnWebSite:
                            jobInfo.ClickOnWebSite = 1;
                            break;
                        case ActionType.ClickOnMap:
                            jobInfo.ClickOnMap = 1;
                            break;
                        case ActionType.ClickOnCall:
                            jobInfo.ClickOnCall = 1;
                            break;
                        case ActionType.ClickOnCard:
                            jobInfo.ClickOnCard = 1;
                            break;
                        case ActionType.JobPageView:
                            jobInfo.Visit = 1;
                            break;
                    }

                    await UnitOfWork.JobInfoRepository.InsertAsync(jobInfo);

                    #endregion
                }
            }

            #region ( Save Changes Async )

            await UnitOfWork.SaveAsync();

            #endregion

            #region ( Remove Cache Data )

            foreach (var itemAction in request.Data)
            {
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobViewsQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
                await DistributedCache.RemoveAsync(key: CacheKeys.JobOverViewQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
                await DistributedCache.RemoveAsync(key: CacheKeys.GetTagsPotentialQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobRankingsByFilterQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
                await DistributedCache.RemoveAsync(key: CacheKeys.GetContactRequestsQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobStatisticsByFilterQuery(Convert.ToInt32(itemAction.JobId)), cancellationToken);
            }

            #endregion

            await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

            result.WithSuccess(Resources.Messages.Successes.ActionIsSuccessfully);
            Logger.LogInformation(Resources.Messages.Successes.ActionIsSuccessfully, new Hashtable(request.Data.ToDictionary()));
        }
        catch (Exception e)
        {
            result.WithError(Resources.Messages.Validations.BadRequestException);
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.Data.ToDictionary()));

            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
        }

        return result;

        #endregion
    }
}
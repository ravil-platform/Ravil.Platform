using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Resources.Messages;
using Domain.Entities.Histories.Enums;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetTagsPotential;

public class GetTagsPotentialQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetTagsPotentialQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetTagsPotentialQuery, List<TagsPotentialViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
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
            var businessOwner = await DistributedCache.GetOrSet(CacheKeys.GetUserByIdQuery(businessOwnerId!),
                async () => await UserManager.FindByIdAsync(businessOwnerId!),
                options: new DistributedCache.CacheOptions
                {
                    ExpireSlidingCacheFromMinutes = 4 * 60,
                    AbsoluteExpirationCacheFromMinutes = 24 * 60
                });

            if (businessOwner is null)
                return Result.Fail(Validations.BadRequestException);

            #endregion

            var businessKeywordsCache = await DistributedCache.GetAsync<List<TagsPotentialViewModel>>(CacheKeys.GetJobRankingsByFilterQuery(request.JobId));
            if (businessKeywordsCache != null)
            {
                result.WithValue(businessKeywordsCache);
            }
            else
            {
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

                #region ( Set Cache )

                await DistributedCache.SetCache(key: CacheKeys.GetTagsPotentialQuery(request.JobId), value: tagsPotential,
                    options: new DistributedCache.CacheOptions
                    {
                        ExpireSlidingCacheFromMinutes = 4 * 60,
                        AbsoluteExpirationCacheFromMinutes = 24 * 60
                    });

                #endregion

                result.WithValue(tagsPotential);
            }

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
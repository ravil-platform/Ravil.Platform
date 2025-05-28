using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetReviewsSummery;

public class GetReviewsSummeryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetReviewsSummeryQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetReviewsSummeryQuery, ReviewsSummeryViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetReviewsSummeryQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<ReviewsSummeryViewModel>> Handle(GetReviewsSummeryQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Reviews Summery Query )

        var result = new Result<ReviewsSummeryViewModel>();

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

            var jobRankingsCache = await DistributedCache.GetAsync<ReviewsSummeryViewModel>(CacheKeys.GetReviewsSummeryQuery(request.JobBranchId));
            if (jobRankingsCache != null)
            {
                result.WithValue(jobRankingsCache);
            }
            else
            {
                var commentReviews = await UnitOfWork.CommentRepository.TableNoTracking
                    .Where(a => a.JobBranchId == request.JobBranchId && a.Rate > 0)
                    .ToListAsync(cancellationToken: cancellationToken);

                var reviewsSummery = new ReviewsSummeryViewModel();
                reviewsSummery.NewCount = commentReviews.Count(a => !a.IsConfirmed);
                reviewsSummery.AverageScore = $"{commentReviews.Sum(a => a.Rate) / commentReviews.Count}";

                #region ( Set Cache )

                await DistributedCache.SetCache(CacheKeys.GetReviewsSummeryQuery(request.JobBranchId), reviewsSummery,
                    options: new DistributedCache.CacheOptions
                    {
                        ExpireSlidingCacheFromMinutes = 4 * 60,
                        AbsoluteExpirationCacheFromMinutes = 24 * 60
                    });

                #endregion

                result.WithValue(reviewsSummery);
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
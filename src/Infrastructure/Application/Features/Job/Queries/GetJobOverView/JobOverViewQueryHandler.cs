using System.Collections;
using AngleSharp.Common;
using Constants.Caching;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetJobOverView;

public class JobOverViewQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<JobOverViewQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<JobOverViewQuery, JobOverViewViewModel>
{
    #region ( Dependencies )
    
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<JobOverViewQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<JobOverViewViewModel>> Handle(JobOverViewQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job OverView Query )

        var result = new Result<JobOverViewViewModel>();

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
            
            var jobInfos = await DistributedCache.GetOrSet(key: CacheKeys.JobOverViewQuery(request.JobId),
                func: async () =>
                {
                    return await UnitOfWork.JobInfoRepository.TableNoTracking
                        .Where(a => a.JobId == request.JobId)
                        .ToListAsync(cancellationToken: cancellationToken);
                },
                options: new DistributedCache.CacheOptions
                {
                    ExpireSlidingCacheFromMinutes = 4 * 60,
                    AbsoluteExpirationCacheFromMinutes = 24 * 60
                });

            if (jobInfos is null) return result;

            var info = new JobOverViewViewModel();
            info.TotalViewCount = jobInfos.Sum(a => a.Visit);
            info.TotalContactRequestCount = jobInfos.Sum(a => a.ClickOnCall)
                + jobInfos.Sum(a => a.ClickOnMap)
                + jobInfos.Sum(a => a.ClickOnChat);

            
            result.WithValue(info);
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
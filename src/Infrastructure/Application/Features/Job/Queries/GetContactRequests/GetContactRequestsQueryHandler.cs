using AngleSharp.Common;
using Constants.Caching;
using System.Collections;
using Resources.Messages;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetContactRequests;

public class GetContactRequestsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    Logging.Base.ILogger<GetContactRequestsQueryHandler> logger,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    IDistributedCache distributedCache)
: IRequestHandler<GetContactRequestsQuery, ContactRequestViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<GetContactRequestsQueryHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<ContactRequestViewModel>> Handle(GetContactRequestsQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Contact Requests Query )

        var result = new Result<ContactRequestViewModel>();

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

            var latestWeekContactsInfo = await DistributedCache.GetOrSet(key: CacheKeys.GetContactRequestsQuery(request.JobId),
            func: async () =>
            {
                return await UnitOfWork.JobInfoRepository.TableNoTracking.Where(a => a.JobId == request.JobId)
                    //.Where(a => a.CreateAt.Day <= DateTime.UtcNow.Day && a.CreateAt.Day >= DateTime.UtcNow.AddDays(-(int)request.DateRange).Day)
                    .Where(a => (a.ClickOnCall > 0 || a.ClickOnChat > 0 || a.ClickOnMap > 0))
                    .ToListAsync(cancellationToken: cancellationToken);
            },
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 24 * 60
            });
            
            var contactRequest = new ContactRequestViewModel();
            if (latestWeekContactsInfo != null)
            {
                contactRequest.TotalContactCount = 
                    latestWeekContactsInfo.Sum(a => a.ClickOnCall)
                    + latestWeekContactsInfo.Sum(a => a.ClickOnMap)
                    + latestWeekContactsInfo.Sum(a => a.ClickOnChat);

                contactRequest.Data = latestWeekContactsInfo.GroupBy(a => a.CreateAt)
                    .Select(group => new ContactRequestDataViewModel
                    {
                        Date = group.Key.ToShamsiDateDashFormat(),
                        EventCount = group.Sum(s => s.ClickOnCall) + group.Sum(s => s.ClickOnMap) + group.Sum(s => s.ClickOnMap)
                    }).ToList();
            }

            result.WithValue(contactRequest);
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
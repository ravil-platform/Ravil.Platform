using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.User.Queries.GetById;

public class GetUserByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager, IDistributedCache distributedCache)
: IRequestHandler<GetUserByIdQuery, ApplicationUserViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;

    #endregion

    public async Task<Result<ApplicationUserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        #region ( Get User By Id Query )

        var user = await DistributedCache.GetOrSet(CacheKeys.GetUserByIdQuery(request.Id),
            async () =>
            {
                return await UnitOfWork.ApplicationUserRepository.TableNoTracking.Include(a => a.Wallet)
                    .Include(a => a.UserSubscriptions.Where(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day))
                    .Where(a => a.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
            },
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 24 * 60
            });

        if (user is null)
        {
            return Result.Ok();
        }

        var result = Mapper.Map<ApplicationUserViewModel>(user);

        return result;

        #endregion
    }
}
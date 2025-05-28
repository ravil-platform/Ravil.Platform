using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.User.Commands.UpdateInfo;

public class UpdateUserInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
    IDistributedCache distributedCache, UserManager<ApplicationUser> userManager)
: IRequestHandler<UpdateUserInfoCommand>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;

    #endregion

    public async Task<Result> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
        #region ( Update User Info Command )

        var user = await UserManager.FindByIdAsync(request.Id);

        if (user is null)
        {
            throw new BadRequestException();
        }

        var updatedUser = Mapper.Map(request, user);

        if (request.BirthDate is not null)
        {
            var birthDate = request.BirthDate.ShamsiDateToDateTime();

            updatedUser.BirthDate = birthDate;
        }

        await UserManager.UpdateAsync(user);
        await UnitOfWork.SaveAsync();

        #region ( Remove Cache Data )

        await DistributedCache.RemoveAsync(key: CacheKeys.GetUserByIdQuery(request.Id), cancellationToken);

        #endregion

        return Result.Ok();

        #endregion
    }
}
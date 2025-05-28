using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.User.Commands.UploadUserAvatar;

public class UploadUserAvatarCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
    IFtpService ftpService, IDistributedCache distributedCache,
    UserManager<ApplicationUser> userManager)
: IRequestHandler<UploadUserAvatarCommand>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;
    protected IDistributedCache DistributedCache { get; } = distributedCache;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;

    #endregion

    public async Task<Result> Handle(UploadUserAvatarCommand request, CancellationToken cancellationToken)
    {
        #region ( Upload User Avatar Command )

        var user = await UnitOfWork.ApplicationUserRepository
            .GetByPredicate(u => u.Id == request.UserId);

        if (user is null)
        {
            throw new BadRequestException();
        }

        var avatar = "";

        avatar = user.Avatar ?? null;
        var avatarName = await FtpService.UploadFileToFtpServer(request.Avatar, TypeFile.Image, Paths.UserServer,
            request.Avatar.FileName, 777, null, null, null, avatar);


        user.Avatar = avatarName;
        user.UpdateDate = DateTime.Now;
        user.LastUpdateDateReason = "تغییر آواتار";

        await UserManager.UpdateAsync(user);
        await UnitOfWork.SaveAsync();

        #region ( Remove Cache Data )

        await DistributedCache.RemoveAsync(key: CacheKeys.GetUserByIdQuery(user.Id), cancellationToken);

        #endregion

        return Result.Ok();

        #endregion
    }
}
namespace Application.Features.User.Commands.UploadUserAvatar;

public class UploadUserAvatarCommandHandler : IRequestHandler<UploadUserAvatarCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public UploadUserAvatarCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        UserManager = userManager;
    }

    public async Task<Result> Handle(UploadUserAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.ApplicationUserRepository
            .GetByPredicate(u => u.Id == request.UserId);

        if (user is null)
        {
            throw new BadRequestException();
        }

        var avatar = "";

        avatar = user.Avatar ?? null;

        var avatarName = request.Avatar
            .SaveFileAndReturnName(Paths.UserServer, TypeFile.Image, null, null, null, avatar);

        user.Avatar = avatarName;
        user.UpdateDate = DateTime.Now;
        user.LastUpdateDateReason = "تغییر آواتار";

        await UserManager.UpdateAsync(user);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}
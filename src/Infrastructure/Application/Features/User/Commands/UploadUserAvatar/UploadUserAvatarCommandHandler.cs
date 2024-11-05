namespace Application.Features.User.Commands.UploadUserAvatar;

public class UploadUserAvatarCommandHandler : IRequestHandler<UploadUserAvatarCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public UploadUserAvatarCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
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

        await UnitOfWork.ApplicationUserRepository.UpdateAsync(user);
        await UnitOfWork.SaveAsync();

        return Result.Ok();
    }
}
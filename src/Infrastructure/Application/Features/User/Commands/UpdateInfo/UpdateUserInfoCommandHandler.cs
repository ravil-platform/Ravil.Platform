namespace Application.Features.User.Commands.UpdateInfo;

public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public UpdateUserInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        UserManager = userManager;
    }

    public async Task<Result> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
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

        return Result.Ok();
    }
}
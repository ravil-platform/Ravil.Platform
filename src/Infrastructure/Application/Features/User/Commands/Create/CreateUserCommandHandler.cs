using AngleSharp.Css.Dom;
using Constants.Security;

namespace Application.Features.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
{
    protected IValidator<CreateUserCommand> Validator { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public CreateUserCommandHandler(IValidator<CreateUserCommand> validator, IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        Validator = validator;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        UserManager = userManager;
    }

    public async Task<Result<ApplicationUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<ApplicationUser>();

        var user = Mapper.Map<ApplicationUser>(request);
        
        user.UserName = request.PhoneNumber;

        var createdResult = await UserManager.CreateAsync(user);

        if (createdResult.Succeeded)
        {
            var roleResult = await UserManager.AddToRoleAsync(user, Roles.User);

            if (roleResult.Succeeded)
            {
                await UnitOfWork.SaveAsync();

                return result.WithValue(user);
            }
            else
            {
                return result.WithError(roleResult.Errors.ToString());
            }
        }

        return result.WithError(createdResult.Errors.ToString());
    }
}
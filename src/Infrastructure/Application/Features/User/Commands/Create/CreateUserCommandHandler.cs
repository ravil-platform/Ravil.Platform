namespace Application.Features.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
{
    protected IValidator<CreateUserCommand> Validator { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }


    public CreateUserCommandHandler(IValidator<CreateUserCommand> validator, IUnitOfWork unitOfWork, IMapper mapper)
    {
        Validator = validator;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
      
    }

    public async Task<Result<ApplicationUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<ApplicationUser>(request);

        await UnitOfWork.ApplicationUserRepository.InsertAsync(user);

        await UnitOfWork.SaveAsync();

        return user;
    }
}
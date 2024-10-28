namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Firstname)
            .NotNull().WithMessage("test");

        RuleFor(u => u.Phone)
            .NotEmpty().WithMessage("not null");
    }
}
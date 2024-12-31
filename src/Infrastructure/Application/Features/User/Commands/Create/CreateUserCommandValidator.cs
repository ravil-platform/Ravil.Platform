namespace Application.Features.User.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Firstname)
            .NotNull().WithMessage("test");

        RuleFor(u => u.PhoneNumber)
            .NotEmpty().WithMessage("not null");
    }
}
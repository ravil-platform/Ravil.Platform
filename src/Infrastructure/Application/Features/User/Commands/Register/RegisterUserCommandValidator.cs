namespace Application.Features.User.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$")
            .WithMessage(Resources.Messages.Validations.PhoneNumberIsInvalid);
    }
}
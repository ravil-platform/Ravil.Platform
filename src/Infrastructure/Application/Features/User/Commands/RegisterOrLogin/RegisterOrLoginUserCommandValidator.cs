namespace Application.Features.User.Commands.RegisterOrLogin;

public class RegisterOrLoginUserCommandValidator : AbstractValidator<RegisterOrLoginUserCommand>
{
    public RegisterOrLoginUserCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$")
            .WithMessage(Resources.Messages.Validations.PhoneNumberIsInvalid);
    }
}
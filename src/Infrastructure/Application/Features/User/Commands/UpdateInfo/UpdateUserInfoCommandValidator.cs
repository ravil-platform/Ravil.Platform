namespace Application.Features.User.Commands.UpdateInfo;

public class UpdateUserInfoCommandValidator : AbstractValidator<UpdateUserInfoCommand>
{
    public UpdateUserInfoCommandValidator()
    {
        RuleFor(r => r.Firstname)
            .NotNull()
            .WithName(Resources.General.DisplayNames.FirstName)
            .WithMessage(Resources.Messages.Validations.RequiredFluent)
            .Length(2, 128)
            .WithName(Resources.General.DisplayNames.FirstName)
            .WithMessage(Resources.Messages.Validations.RangeInvalidFluent);

        RuleFor(r => r.Lastname)
            .NotNull()
            .WithName(Resources.General.DisplayNames.LastName)
            .WithMessage(Resources.Messages.Validations.RequiredFluent).Length(2, 128)
            .WithName(Resources.General.DisplayNames.LastName)
            .WithMessage(Resources.Messages.Validations.RangeInvalidFluent);

        RuleFor(r => r.NationalCode)
            .Matches(RegularExpression.NationalCode)
            .WithMessage(Resources.Messages.Validations.NationalCodeIsInvalid);

        /*RuleFor(r => r.Email)
            .Matches(RegularExpression.EmailAddress)
            .WithMessage(Resources.Messages.Validations.EmailAddressInvalid);*/

        /*RuleFor(r => r.Phone)
            .Matches(RegularExpression.PhoneNumber)
            .WithMessage(Resources.Messages.Validations.PhoneNumberIsInvalid);*/
    }
}
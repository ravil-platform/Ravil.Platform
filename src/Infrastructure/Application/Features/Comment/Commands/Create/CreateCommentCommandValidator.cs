namespace Application.Features.Comment.Commands.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(r => r.CommentText)
            .NotNull()
            .WithName(Resources.General.DisplayNames.Comments)
            .WithMessage(Resources.Messages.Validations.RequiredFluent);

        RuleFor(r => r.Phone)
            .Matches(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$")
            .WithMessage(Resources.Messages.Validations.PhoneNumberIsInvalid);

        RuleFor(r => r.Email)
            .EmailAddress()
            .WithMessage(Resources.Messages.Validations.EmailAddressInvalid);
    }
}
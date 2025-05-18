namespace Application.Features.Job.Commands.UpdateBusiness;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(r => r.Title)
            .MaximumLength(MaxLength.Title)
            .WithName(Resources.General.DisplayNames.Title)
            .WithMessage(Resources.Messages.Validations.MaxLengthFluent);

        RuleFor(r => r.Summary)
            .MaximumLength(MaxLength.Summary)
            .WithName(Resources.General.DisplayNames.Summary)
            .WithMessage(Resources.Messages.Validations.MaxLengthFluent);

        RuleFor(r => r.Description)
            .MaximumLength(MaxLength.Description)
            .WithName(Resources.General.DisplayNames.Description)
            .WithMessage(Resources.Messages.Validations.MaxLengthFluent);
    }
}
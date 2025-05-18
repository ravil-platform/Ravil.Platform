namespace Application.Features.GuideLine.Commands.GuideLineCompletion;

public class GuideLineCompletionCommandValidator : AbstractValidator<GuideLineCompletionCommand>
{
    public GuideLineCompletionCommandValidator()
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
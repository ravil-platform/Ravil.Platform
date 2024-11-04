namespace Application.Features.Job.Commands.CreateJobBranch;

public class CreateJobBranchCommandValidator : AbstractValidator<CreateJobBranchCommand>
{
    public CreateJobBranchCommandValidator()
    {
        RuleFor(r => r.Route)
            .Matches(RegularExpression.AlphanumericWithSpace)
            .WithMessage(Resources.Messages.Validations.OnlyTypeEnglish);

        RuleFor(r => r.Title)
            .NotEmpty()
            .WithName(Resources.General.DisplayNames.Title)
            .WithMessage(Resources.Messages.Validations.RequiredFluent)
            .NotNull()
            .WithName(Resources.General.DisplayNames.Title)
            .WithMessage(Resources.Messages.Validations.RequiredFluent);

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithName(Resources.General.DisplayNames.Description)
            .WithMessage(Resources.Messages.Validations.RequiredFluent)
            .NotNull()
            .WithName(Resources.General.DisplayNames.Description)
            .WithMessage(Resources.Messages.Validations.RequiredFluent);
    }
}
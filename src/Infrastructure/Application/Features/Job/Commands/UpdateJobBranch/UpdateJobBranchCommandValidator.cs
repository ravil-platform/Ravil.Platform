namespace Application.Features.Job.Commands.UpdateJobBranch
{
    public class UpdateJobBranchCommandValidator : AbstractValidator<UpdateJobBranchCommand>
    {
        public UpdateJobBranchCommandValidator()
        {
            RuleFor(r => r.CreateJobBranchViewModel.Route)
                .Matches(RegularExpression.AlphanumericWithSpace)
                .WithMessage(Resources.Messages.Validations.OnlyTypeEnglish);

            RuleFor(r => r.CreateJobBranchViewModel.Title)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);

            RuleFor(r => r.CreateJobBranchViewModel.Description)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Description)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Description)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);
        }
    }
}

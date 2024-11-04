namespace Application.Features.Job.Commands.CreateFreeJobBranch
{
    public class CreateFreeJobBranchCommandValidator : AbstractValidator<CreateFreeJobBranchCommand>
    {
        public CreateFreeJobBranchCommandValidator()
        {
            #region ( Job )
            RuleFor(r => r.Job.Route)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Route)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Route)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .Matches(RegularExpression.AlphanumericWithSpace)
                .WithMessage(Resources.Messages.Validations.OnlyTypeEnglish);


            RuleFor(r => r.Job.Title)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);


            RuleFor(r => r.Job.SubTitle)
                .NotNull()
                .WithName(Resources.General.DisplayNames.SubTitle)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.SubTitle)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);


            RuleFor(r => r.Job.Summary)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Summary)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Summary)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);



            RuleFor(r => r.Job.Content)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .MaximumLength(MaxLength.Content)
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.MaxLengthFluent);
            #endregion

            #region ( Job Branch )
            RuleFor(r => r.JobBranch.Route)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Route)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Route)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .Matches(RegularExpression.AlphanumericWithSpace)
                .WithMessage(Resources.Messages.Validations.OnlyTypeEnglish);


            RuleFor(r => r.JobBranch.Title)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Title)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);


            RuleFor(r => r.JobBranch.BranchContent)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .NotEmpty()
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.RequiredFluent)
                .MaximumLength(MaxLength.Content)
                .WithName(Resources.General.DisplayNames.Content)
                .WithMessage(Resources.Messages.Validations.MaxLengthFluent);
            #endregion

            RuleFor(r=> r.PostalCode)
                .Matches(RegularExpression.PostalCode)
                .WithMessage(Resources.Messages.Validations.PostalCodeIsInvalid);
        }
    }
}

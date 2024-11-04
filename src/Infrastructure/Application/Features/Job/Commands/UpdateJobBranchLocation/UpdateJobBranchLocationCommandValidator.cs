namespace Application.Features.Job.Commands.UpdateJobBranchLocation
{
    public class UpdateJobBranchLocationCommandValidator : AbstractValidator<UpdateJobBranchLocationCommand>
    {
        public UpdateJobBranchLocationCommandValidator()
        {
            RuleFor(r => r.LocationViewModel.Route)
                .Matches(RegularExpression.AlphanumericWithSpace)
                .WithMessage(Resources.Messages.Validations.OnlyTypeEnglish);

            RuleFor(r => r.AddressViewModel.PostalCode)
                .Matches(RegularExpression.PostalCode)
                .WithMessage(Resources.Messages.Validations.PostalCodeIsInvalid);
        }
    }
}
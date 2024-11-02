namespace Application.Features.Banner.GetAllByBranchId
{
    public class GetAllBannersByBranchIdQueryValidator : AbstractValidator<GetAllBannersByBranchIdQuery>
    {
        public GetAllBannersByBranchIdQueryValidator()
        {
            RuleFor(r => r.JobBranchId)
                .NotEqual("null")
                .WithName(Resources.General.DisplayNames.Id)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);
        }
    }
}

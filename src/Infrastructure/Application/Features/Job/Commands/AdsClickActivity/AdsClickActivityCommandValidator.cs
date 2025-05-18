namespace Application.Features.Job.Commands.AdsClickActivity;

public class AdsClickActivityCommandValidator : AbstractValidator<AdsClickActivityCommand>
{
    public AdsClickActivityCommandValidator()
    {
        RuleFor(j => j.SubscriptionId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("not null");

        RuleFor(j => j.KeywordSlug)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not Empty");

        RuleFor(j => j.KeywordPageUrl)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not empty");

        RuleFor(j => j.KeywordPageTitle)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not empty");
    }
}
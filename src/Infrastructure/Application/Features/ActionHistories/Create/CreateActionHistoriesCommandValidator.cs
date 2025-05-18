namespace Application.Features.ActionHistories.Create;

public class CreateActionHistoriesCommandValidator : AbstractValidator<CreateActionHistoriesCommandData>
{
    public CreateActionHistoriesCommandValidator()
    {
        RuleFor(j => j.JobBranchId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not Empty");

        RuleFor(j => j.ActionType)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("not Empty");

        RuleFor(j => j.PageSlug)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not Empty");

        RuleFor(j => j.PageTitle)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not empty");

        RuleFor(j => j.PageUrl)
            .NotEmpty().WithMessage("not null")
            .NotNull().WithMessage("not empty");
    }
}
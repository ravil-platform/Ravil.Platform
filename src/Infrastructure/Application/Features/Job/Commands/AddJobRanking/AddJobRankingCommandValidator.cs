namespace Application.Features.Job.Commands.AddJobRanking;

public class AddJobRankingCommandValidator : AbstractValidator<AddJobRankingCommandData>
{
    public AddJobRankingCommandValidator()
    {
        RuleFor(j => j.PageUrl)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(Resources.Messages.Validations.RequiredFluent)
            .NotNull()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);
    }
}
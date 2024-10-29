namespace Application.Features.Job.Commands.Create
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(j => j.Route)
                .NotEmpty().WithMessage("not null")
                .NotNull().WithMessage("not Empty");

            RuleFor(j => j.Title)
                .NotEmpty().WithMessage("not null")
                .NotNull().WithMessage("not empty");

            RuleFor(j => j.Content)
                .NotEmpty().WithMessage("not null")
                .NotNull().WithMessage("not empty");
        }
    }
}

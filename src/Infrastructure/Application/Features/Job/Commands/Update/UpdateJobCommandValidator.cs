namespace Application.Features.Job.Commands.Update
{
    public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator()
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

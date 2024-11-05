namespace Application.Features.Job.Commands.UploadJobBranchVideo
{
    public class UploadJobBranchVideoCommandValidator : AbstractValidator<UploadJobBranchVideoCommand>
    {
        public UploadJobBranchVideoCommandValidator()
        {
            RuleFor(r => r.Video)
                .NotNull()
                .WithName(Resources.General.DisplayNames.Video)
                .WithMessage(Resources.Messages.Validations.RequiredFluent);
        }
    }
}

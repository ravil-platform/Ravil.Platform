namespace Application.Features.Job.Commands.UploadJobBranchGalleries;

public class UploadJobBranchGalleriesCommandValidator : AbstractValidator<UploadJobBranchGalleriesCommand>
{
    public UploadJobBranchGalleriesCommandValidator()
    {
        RuleFor(r => r.Images)
            .NotNull()
            .WithName(Resources.General.DisplayNames.Image)
            .WithMessage(Resources.Messages.Validations.RequiredFluent);
    }
}
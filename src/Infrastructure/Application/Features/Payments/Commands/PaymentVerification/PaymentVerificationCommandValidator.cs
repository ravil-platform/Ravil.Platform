namespace Application.Features.Payments.Commands.PaymentVerification;

public class PaymentVerificationCommandValidator : AbstractValidator<PaymentVerificationCommand>
{
    public PaymentVerificationCommandValidator()
    {
        RuleFor(r => r.PaymentId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);

        RuleFor(r => r.PortalId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);

        RuleFor(r => r.Status)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);

        RuleFor(r => r.Authority)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);
    }
}
namespace Application.Features.Payments.Commands.Payment;

public class PaymentCommandValidator : AbstractValidator<PaymentCommand>
{
    public PaymentCommandValidator()
    {
        RuleFor(r => r.SubscriptionId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .WithMessage(Resources.Messages.Validations.RequiredFluent)
            .GreaterThan(0);

        RuleFor(r => r.PortalId)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .WithMessage(Resources.Messages.Validations.RequiredFluent);
    }
}
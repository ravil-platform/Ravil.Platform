using ViewModels.QueriesResponseViewModel.Payments;

namespace Application.Features.Payments.Commands.PaymentVerification
{
    public class PaymentVerificationCommand : IRequest<PaymentVerificationResponseViewModel>
    {
        public int PortalId { get; set; }
        public Guid PaymentId { get; set; }
        public string Status { get; set; } = null!;
        public string Authority { get; set; } = null!;
    }
}
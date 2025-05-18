using ViewModels.QueriesResponseViewModel.Payments;

namespace Application.Features.Payments.Commands.Payment
{
    public class PaymentCommand : IRequest<PaymentActionResponseViewModel>
    {
        public int SubscriptionId { get; set; }
        public int PortalId { get; set; }
    }
}

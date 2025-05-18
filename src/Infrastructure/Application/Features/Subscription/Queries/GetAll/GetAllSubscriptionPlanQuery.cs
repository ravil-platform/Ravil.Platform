using ViewModels.QueriesResponseViewModel.MessageBox;
using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Subscription.Queries.GetAll;

public class GetAllSubscriptionPlanQuery : IRequest<List<SubscriptionViewModel>>
{
    public SubscriptionType? SubscriptionType { get; set; }
    public SubscriptionDurationType? DurationType { get; set; }
}
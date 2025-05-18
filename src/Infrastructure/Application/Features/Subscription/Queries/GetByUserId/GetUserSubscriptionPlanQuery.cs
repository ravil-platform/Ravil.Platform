using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Subscription.Queries.GetByUserId;

public class GetUserSubscriptionPlanQuery : IRequest<UserSubscriptionViewModel>
{
    public string UserId { get; set; } = null!;
}
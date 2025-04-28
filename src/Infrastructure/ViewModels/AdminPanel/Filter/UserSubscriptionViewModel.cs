using Domain.Entities.Subscription;

namespace ViewModels.AdminPanel.Filter;

public class UserSubscriptionFilterViewModel : Paging<UserSubscription>
{
    public int? SubscriptionId { get; set; }

    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    public bool FindAll { get; set; }
}
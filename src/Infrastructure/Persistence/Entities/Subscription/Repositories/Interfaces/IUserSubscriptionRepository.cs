using Domain.Entities.Subscription;
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Subscription.Repositories.Interfaces;

public interface IUserSubscriptionRepository : IRepository<UserSubscription>
{
    UserSubscriptionFilterViewModel GetByFilter(UserSubscriptionFilterViewModel filter);
}
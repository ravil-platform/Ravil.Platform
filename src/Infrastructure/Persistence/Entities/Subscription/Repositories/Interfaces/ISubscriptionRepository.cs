namespace Persistence.Entities.Subscription.Repositories.Interfaces;

public interface ISubscriptionRepository : IRepository<Domain.Entities.Subscription.Subscription>
{
    Task SetIsDelete(int subscriptionId, bool delete);
}
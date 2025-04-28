using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class SubscriptionRepository : Repository<Domain.Entities.Subscription.Subscription>, ISubscriptionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal SubscriptionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task SetIsDelete(int subscriptionId, bool delete)
    {
        var subscription = await ApplicationDbContext.Subscription.SingleOrDefaultAsync(j => j.Id == subscriptionId);

        if (subscription != null)
        {
            subscription.IsActive = delete;
        }
    }
}
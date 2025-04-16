using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class SubscriptionRepository : Repository<Domain.Entities.Subscription.Subscription>, ISubscriptionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal SubscriptionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
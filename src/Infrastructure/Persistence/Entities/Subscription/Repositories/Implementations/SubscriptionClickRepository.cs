using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class SubscriptionClickRepository : Repository<SubscriptionClick>, ISubscriptionClickRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal SubscriptionClickRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
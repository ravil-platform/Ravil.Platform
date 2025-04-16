using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class UserSubscriptionRepository : Repository<UserSubscription>, IUserSubscriptionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal UserSubscriptionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
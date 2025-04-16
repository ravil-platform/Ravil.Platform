using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class SubscriptionFeatureRepository : Repository<SubscriptionFeature>, ISubscriptionFeatureRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal SubscriptionFeatureRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
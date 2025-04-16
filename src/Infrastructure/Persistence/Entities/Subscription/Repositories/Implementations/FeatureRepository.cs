using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal FeatureRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
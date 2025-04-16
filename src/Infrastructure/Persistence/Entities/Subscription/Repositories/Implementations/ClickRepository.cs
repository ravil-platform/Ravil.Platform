using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;

namespace Persistence.Entities.Subscription.Repositories.Implementations
{
    public class ClickRepository : Repository<Click>, IClickRepository
    {
        protected ApplicationDbContext ApplicationDbContext { get; }
        internal ClickRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
    }
}

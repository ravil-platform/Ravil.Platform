namespace Persistence.Entities.Category.Repositories;

public class TargetRepository : Repository<Target>, ITargetRepository
{
    internal TargetRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
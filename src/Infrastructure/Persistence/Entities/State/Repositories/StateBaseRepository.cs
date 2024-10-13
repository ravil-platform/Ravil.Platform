namespace Persistence.Entities.State.Repositories;

public class StateBaseRepository : Repository<StateBase>, IStateBaseRepository
{
    internal StateBaseRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
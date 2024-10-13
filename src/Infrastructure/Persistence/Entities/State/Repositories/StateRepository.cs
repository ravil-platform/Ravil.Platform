namespace Persistence.Entities.State.Repositories;

public class StateRepository : Repository<Domain.Entities.State.State>, IStateRepository
{
    internal StateRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
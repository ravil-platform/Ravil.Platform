namespace Persistence.Entities.Histories.Repositories;

public class ActionHistoriesRepository : Repository<ActionHistories> , IActionHistoriesRepository
{
    internal ActionHistoriesRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
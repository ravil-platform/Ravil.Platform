namespace Persistence.Entities.Config.Repositories;

public class ConfigRepository : Repository<Domain.Entities.Config.Config>, IConfigRepository
{
    internal ConfigRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
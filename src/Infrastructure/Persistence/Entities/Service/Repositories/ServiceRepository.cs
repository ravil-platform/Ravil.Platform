namespace Persistence.Entities.Service.Repositories;

public class ServiceRepository : Repository<Domain.Entities.Service.Service>, IServiceRepository
{
    internal ServiceRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
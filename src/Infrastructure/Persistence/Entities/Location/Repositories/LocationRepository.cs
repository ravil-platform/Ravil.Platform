namespace Persistence.Entities.Location.Repositories;

public class LocationRepository : Repository<Domain.Entities.Location.Location>, ILocationRepository
{
    internal LocationRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
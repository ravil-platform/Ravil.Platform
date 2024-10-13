namespace Persistence.Entities.City.Repositories;

public class CityRepository : Repository<Domain.Entities.City.City>, ICityRepository
{
    internal CityRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
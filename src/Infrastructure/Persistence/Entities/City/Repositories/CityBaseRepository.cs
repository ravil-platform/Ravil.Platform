namespace Persistence.Entities.City.Repositories;

public class CityBaseRepository : Repository<CityBase>, ICityBaseRepository
{
    internal CityBaseRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
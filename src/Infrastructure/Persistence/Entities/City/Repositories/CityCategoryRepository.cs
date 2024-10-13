namespace Persistence.Entities.City.Repositories;

public class CityCategoryRepository : Repository<CityCategory>, ICityCategoryRepository
{
    internal CityCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
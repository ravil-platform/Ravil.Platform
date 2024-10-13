namespace Persistence.Entities.Brand.Repositories;

public class BrandRepository : Repository<Domain.Entities.Brand.Brand>, IBrandRepository
{
    internal BrandRepository(DbContext databaseContext) : base(databaseContext)
    {

    }
}
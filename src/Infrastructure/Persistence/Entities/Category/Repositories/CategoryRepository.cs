namespace Persistence.Entities.Category.Repositories;

public class CategoryRepository : Repository<Domain.Entities.Category.Category>, ICategoryRepository
{
    internal CategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.Category.Repositories;

public class CategoryServiceRepository : Repository<CategoryService>, ICategoryServiceRepository
{
    internal CategoryServiceRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
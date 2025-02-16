namespace Persistence.Entities.Category.Repositories;

public class CategoryTagRepository : Repository<CategoryTag>, ICategoryTagRepository
{
    internal CategoryTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
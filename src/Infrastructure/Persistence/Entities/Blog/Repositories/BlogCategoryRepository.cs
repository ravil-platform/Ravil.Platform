namespace Persistence.Entities.Blog.Repositories;

public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
{
    internal BlogCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.Blog.Repositories;

public class BlogCategoryRelRepository : Repository<BlogCategoryRel>, IBlogCategoryRelRepository
{
    internal BlogCategoryRelRepository(DbContext databaseContext) : base(databaseContext)
    {

    }
}
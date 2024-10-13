namespace Persistence.Entities.Blog.Repositories;

public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
{
    internal BlogTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
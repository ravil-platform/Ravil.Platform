namespace Persistence.Entities.Blog.Repositories;

public class BlogRepository : Repository<Domain.Entities.Blog.Blog>, IBlogRepository
{
    internal BlogRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
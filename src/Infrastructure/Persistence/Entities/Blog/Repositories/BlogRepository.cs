namespace Persistence.Entities.Blog.Repositories;

public class BlogRepository : Repository<Domain.Entities.Blog.Blog>, IBlogRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal BlogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
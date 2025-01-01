namespace Persistence.Entities.Category.Repositories;

public class CategoryRepository : Repository<Domain.Entities.Category.Category>, ICategoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<List<Domain.Entities.Category.Category>> GetMainCategories()
    {
        var categories =
            await ApplicationDbContext.Category.Where(c =>
                c.ParentId == 0 && c.NodeLevel == 1 && c.IsActive).ToListAsync();

        return categories;
    }

    public async Task<string> GetTargetRoute(int categoryId)
    {
        string route = await ApplicationDbContext.Category.Where(c => c.Id == categoryId).Select(c => c.Route).SingleAsync();

        return route;
    }

    public async Task<List<Domain.Entities.Category.Category>> SetTargetRoutes(List<Domain.Entities.Category.Category> categories)
    {
        var targets = await ApplicationDbContext.Targets.ToListAsync();

        foreach (var category in categories)
        {
            if (targets.Any(t => t.OriginCategoryId == category.Id))
            {
                var destinationCategoryId = targets.Where(t => t.OriginCategoryId == category.Id).Select(t => t.DestinationCategoryId).Single();

                var route = await GetTargetRoute(destinationCategoryId);

                category.Route = route;
            }
        }

        return categories;
    }

    public async Task<List<Domain.Entities.Category.Category>> GetChildCategories(int nodeLevel, int parentId)
    {
        var categories =
            await ApplicationDbContext.Category.Where(c =>
                c.ParentId == parentId && c.NodeLevel == nodeLevel && c.IsActive).ToListAsync();

        return categories;
    }
}
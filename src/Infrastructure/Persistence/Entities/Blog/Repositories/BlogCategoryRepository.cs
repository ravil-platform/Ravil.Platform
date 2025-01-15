using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Blog.Repositories;

public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal BlogCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public BlogCategoryFilterViewModel GetByFilter(BlogCategoryFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.BlogCategory.OrderBy(b => b.Sort).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }

    public async Task SetActivation(int id, bool isActive)
    {
        var blogCategory = await GetByIdAsync(id);

        blogCategory.IsDeleted = isActive;
    }
}
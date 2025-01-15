using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Blog.Repositories;

public class BlogRepository : Repository<Domain.Entities.Blog.Blog>, IBlogRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal BlogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public BlogFilterAdminViewModel GetByFilterAdmin(BlogFilterAdminViewModel filter)
    {
        var query =
            ApplicationDbContext.Blog.OrderByDescending(b => b.CreateDate).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Slug))
        {
            query = query.Where(a => a.Route.Contains(filter.Slug.ToSlug().Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Summary))
        {
            query = query.Where(a => a.Summary.Contains(filter.Summary.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Content))
        {
            query = query.Where(a => a.Content.Contains(filter.Content.Trim()));
        }

        if (filter.IsActive != null)
        {
            query = query.Where(a => a.IsDeleted == filter.IsActive);
        }

        if (filter.CanonicalSeo != null)
        {
            query = query.Where(a => a.CanonicalMeta == filter.CanonicalSeo);
        }

        if (filter.IndexSeo != null)
        {
            query = query.Where(a => a.CanonicalMeta == filter.IndexSeo);
        }

        if (filter.SortBy != null)
        {
            if (filter.SortBy == SortBy.MostViewed)
            {
                query = query.OrderByDescending(a => a.ViewCount);
            }
            else if (filter.SortBy == SortBy.Newest)
            {
                query = query.OrderByDescending(a => a.CreateDate);
            }
            else if (filter.SortBy == SortBy.Oldest)
            {
                query = query.OrderBy(a => a.CreateDate);
            }
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }


    public async Task SetDelete(int id, bool isDelete)
    {
        var blog = await GetByIdAsync(id);

        blog.IsDeleted = isDelete;
    }
}
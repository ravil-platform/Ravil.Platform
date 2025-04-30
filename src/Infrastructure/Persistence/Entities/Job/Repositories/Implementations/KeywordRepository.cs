namespace Persistence.Entities.Job.Repositories.Implementations;

public class KeywordRepository : Repository<Keyword>, IKeywordRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal KeywordRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public KeywordFilterViewModel GetByFilter(KeywordFilterViewModel filter)
    {
        var query =
          ApplicationDbContext.Keyword.Include(k => k.Category)
              .AsQueryable();

        if (filter.FindAll)
        {
            #region ( Find All )
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region ( Filter )
        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title));
        }

        if (!string.IsNullOrWhiteSpace(filter.Slug))
        {
            query = query.Where(a => a.Slug.Contains(filter.Slug.ToSlug().Trim()));
        }

        if (filter.CategoryId != null)
        {
            query = query.Where(a => a.CategoryId == filter.CategoryId);
        }

        if (filter.IsActive != null)
        {
            query = query.Where(a => a.IsActive == filter.IsActive);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }

    public async Task<bool> SlugExist(string slug)
    {
        return await ApplicationDbContext.Keyword.AnyAsync(j => j.Slug == slug.ToSlug());
    }

    public async Task<bool> SlugExist(Guid id, string slug)
    {
        return await ApplicationDbContext.Keyword.AnyAsync(j => j.Slug == slug.ToSlug() && j.Id != id);
    }
}
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Category.Repositories;

public class CategoriesCityContentRepository : Repository<CategoriesCityContent>, ICategoriesCityContentRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal CategoriesCityContentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public CategoriesCityContentsFilterViewModel GetByFilterAdmin(CategoriesCityContentsFilterViewModel filter)
    {
        var query = ApplicationDbContext.CategoriesCityContents.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (filter.CityId != null)
        {
            query = query.Where(a => a.CityId == filter.CityId);
        }

        if (filter.CategoryId != null)
        {
            query = query.Where(a => a.CategoryId == filter.CategoryId);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
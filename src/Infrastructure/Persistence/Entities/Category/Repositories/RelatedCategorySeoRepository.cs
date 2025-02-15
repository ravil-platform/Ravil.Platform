using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Category.Repositories;

public class RelatedCategorySeoRepository : Repository<RelatedCategorySeo> , IRelatedCategorySeoRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal RelatedCategorySeoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public RelatedCategorySeoFilterViewModel GetByFilterAdmin(RelatedCategorySeoFilterViewModel filter)
    {
        var query = ApplicationDbContext.RelatedCategorySeo.AsQueryable();

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
            query = query.Where(a => a.CurrentCityId == filter.CityId);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
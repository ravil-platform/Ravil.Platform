using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.City.Repositories;

public class CityBaseRepository : Repository<CityBase>, ICityBaseRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal CityBaseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public CityBaseFilterViewModel GetByFilterAdmin(CityBaseFilterViewModel filter)
    {
        var query = ApplicationDbContext.CityBase.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(a => a.Name.Contains(filter.Name.Trim()));
        }

        //state

        if (filter.StateId != null)
        {
            query.Where(a => a.StateId == filter.StateId);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
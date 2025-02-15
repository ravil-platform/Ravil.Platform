using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.City.Repositories;

public class CityRepository : Repository<Domain.Entities.City.City>, ICityRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal CityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public CityFilterViewModel GetByFilterAdmin(CityFilterViewModel filter)
    {
        var query = ApplicationDbContext.City.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.SubTitle))
        {
            query = query.Where(a => a.Subtitle.Contains(filter.SubTitle.Trim()));
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
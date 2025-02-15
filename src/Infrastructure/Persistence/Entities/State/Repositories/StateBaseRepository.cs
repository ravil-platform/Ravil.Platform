using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.State.Repositories;

public class StateBaseRepository : Repository<StateBase>, IStateBaseRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal StateBaseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public StateBaseFilterViewModel GetByFilterAdmin(StateBaseFilterViewModel filter)
    {
        var query = ApplicationDbContext.StateBase.AsQueryable();

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
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
namespace Persistence.Entities.PanelTutorial.Repositories;

public class PanelTutorialRepository : Repository<Domain.Entities.PanelTutorial.PanelTutorial>, IPanelTutorialRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal PanelTutorialRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public PanelTutorialFilterViewModel GetByFilter(PanelTutorialFilterViewModel filter)
    {
        var query = ApplicationDbContext.PanelTutorial.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title));
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
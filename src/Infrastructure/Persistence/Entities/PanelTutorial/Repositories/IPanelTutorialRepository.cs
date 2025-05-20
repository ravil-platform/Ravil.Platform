namespace Persistence.Entities.PanelTutorial.Repositories
{
    public interface IPanelTutorialRepository : IRepository<Domain.Entities.PanelTutorial.PanelTutorial>
    {
        PanelTutorialFilterViewModel GetByFilter(PanelTutorialFilterViewModel filter);
    }
}

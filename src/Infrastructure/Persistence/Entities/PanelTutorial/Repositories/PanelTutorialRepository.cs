namespace Persistence.Entities.PanelTutorial.Repositories;

public class PanelTutorialRepository : Repository<Domain.Entities.PanelTutorial.PanelTutorial>, IPanelTutorialRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal PanelTutorialRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
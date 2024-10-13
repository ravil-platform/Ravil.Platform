namespace Persistence.Entities.MainSlider.Repositories;

public class MainSliderRepository : Repository<Domain.Entities.MainSlider.MainSlider>, IMainSliderRepository
{
    internal MainSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
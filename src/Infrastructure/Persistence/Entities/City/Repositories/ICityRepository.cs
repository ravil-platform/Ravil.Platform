using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.City.Repositories
{
    public interface ICityRepository : IRepository<Domain.Entities.City.City>
    {
        CityFilterViewModel GetByFilterAdmin(CityFilterViewModel filter);
    }
}

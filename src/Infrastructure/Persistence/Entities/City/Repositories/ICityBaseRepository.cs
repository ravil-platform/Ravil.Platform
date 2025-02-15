using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.City.Repositories;

public interface ICityBaseRepository : IRepository<CityBase>
{
    CityBaseFilterViewModel GetByFilterAdmin(CityBaseFilterViewModel filter);
}
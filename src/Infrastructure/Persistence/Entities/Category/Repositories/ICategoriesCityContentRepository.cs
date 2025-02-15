using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Category.Repositories;

public interface ICategoriesCityContentRepository : IRepository<CategoriesCityContent>
{
    CategoriesCityContentsFilterViewModel GetByFilterAdmin(CategoriesCityContentsFilterViewModel filter);
}


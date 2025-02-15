using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Category.Repositories;

public interface IRelatedCategorySeoRepository : IRepository<RelatedCategorySeo>
{
    RelatedCategorySeoFilterViewModel GetByFilterAdmin(RelatedCategorySeoFilterViewModel filter);
}
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IKeywordRepository : IRepository<Keyword>
{
    KeywordFilterViewModel GetByFilter(KeywordFilterViewModel filter);
}
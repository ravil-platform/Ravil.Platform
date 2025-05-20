namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IKeywordRepository : IRepository<Keyword>
{
    KeywordFilterViewModel GetByFilter(KeywordFilterViewModel filter);

    Task<bool> SlugExist(string slug);
    Task<bool> SlugExist(Guid id, string slug);
}
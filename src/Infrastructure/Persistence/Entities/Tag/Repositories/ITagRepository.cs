using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Tag.Repositories
{
    public interface ITagRepository : IRepository<Domain.Entities.Tag.Tag>
    {
        TagsFilterViewModel GetByFilter(TagsFilterViewModel filter);
    }
}

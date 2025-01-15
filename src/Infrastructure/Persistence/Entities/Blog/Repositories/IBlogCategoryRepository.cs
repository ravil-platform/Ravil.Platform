using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Blog.Repositories
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        BlogCategoryFilterViewModel GetByFilter(BlogCategoryFilterViewModel filter);

        Task SetActivation(int id, bool isActive);
    }
}

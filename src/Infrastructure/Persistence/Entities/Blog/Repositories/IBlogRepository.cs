using ViewModels.AdminPanel.Filter.Blog;

namespace Persistence.Entities.Blog.Repositories
{
    public interface IBlogRepository : IRepository<Domain.Entities.Blog.Blog>
    {
        BlogFilterAdminViewModel GetByFilterAdmin(BlogFilterAdminViewModel filter);
        Task SetDelete(int id, bool isDelete);
    }
}

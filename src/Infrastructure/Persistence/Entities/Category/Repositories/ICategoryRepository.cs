namespace Persistence.Entities.Category.Repositories
{
    public interface ICategoryRepository : IRepository<Domain.Entities.Category.Category>
    {
        Task<List<Domain.Entities.Category.Category>> GetMainCategories();
        Task<List<Domain.Entities.Category.Category>> GetChildCategories(int nodeLevel, int parentId);
        Task<string> GetTargetRoute(int categoryId);

        Task<List<Domain.Entities.Category.Category>> SetTargetRoutes(List<Domain.Entities.Category.Category> categories);
    }
}

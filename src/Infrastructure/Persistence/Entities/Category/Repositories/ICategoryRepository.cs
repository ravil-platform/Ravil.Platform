using ViewModels.AdminPanel.Filter;
using ViewModels.Filter.Category;
using ViewModels.QueriesResponseViewModel.Category;

namespace Persistence.Entities.Category.Repositories
{
    public interface ICategoryRepository : IRepository<Domain.Entities.Category.Category>
    {
        Task<List<Domain.Entities.Category.Category>> GetMainCategories();
        Task<List<Domain.Entities.Category.Category>> GetChildCategories(int nodeLevel, int parentId);

        Task<string> GetTargetRoute(int categoryId);
        Task<bool> RouteExist(string route);
        Task<bool> RouteExist(string route, int categoryId);



        Task<List<Domain.Entities.Category.Category>> SetTargetRoutes(List<Domain.Entities.Category.Category> categories);
        Task<List<CategoryViewModel>> SetTargetRoutes(List<CategoryViewModel> categories);

        Task<List<Domain.Entities.Category.Category>> ReplaceCategoryContent(List<Domain.Entities.Category.Category> categories, int cityId);
        Task<string?> ReplaceCategoryContent(Domain.Entities.Category.Category category, int cityId);


        CategoriesFilterViewModel GetByAdminFilter(CategoriesFilterViewModel filter);
    }
}

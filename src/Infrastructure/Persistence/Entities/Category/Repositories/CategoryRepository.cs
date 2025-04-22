using Domain.Entities.City;
using Microsoft.EntityFrameworkCore;
using ViewModels.AdminPanel.Filter;
using ViewModels.Filter.Category;
using ViewModels.QueriesResponseViewModel.Category;

namespace Persistence.Entities.Category.Repositories;

public class CategoryRepository : Repository<Domain.Entities.Category.Category>, ICategoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<List<Domain.Entities.Category.Category>> GetMainCategories()
    {
        var categories =
            await ApplicationDbContext.Category.Where(c =>
                c.ParentId == 0 && c.NodeLevel == 1 && c.IsActive).ToListAsync();

        return categories;
    }

    public async Task<string> GetTargetRoute(int categoryId)
    {
        string route = await ApplicationDbContext.Category.Where(c => c.Id == categoryId).Select(c => c.Route).SingleAsync();

        return route;
    }

    public async Task<bool> RouteExist(string route)
    {
        return await ApplicationDbContext.Category.AnyAsync(j => j.Route == route.ToSlug());
    }

    //use for Update
    public async Task<bool> RouteExist(string route, int categoryId)
    {
        return await ApplicationDbContext.Category.AnyAsync(j => j.Route == route.ToSlug() && j.Id != categoryId);
    }

    public async Task<List<Domain.Entities.Category.Category>> SetTargetRoutes(List<Domain.Entities.Category.Category> categories)
    {
        var targets = await ApplicationDbContext.Targets.ToListAsync();

        foreach (var category in categories)
        {
            if (targets.Any(t => t.OriginCategoryId == category.Id))
            {
                var destinationCategoryId = targets.Where(t => t.OriginCategoryId == category.Id).Select(t => t.DestinationCategoryId).Single();

                var route = await GetTargetRoute(destinationCategoryId);

                category.Route = route;
            }
        }

        return categories;
    }

    public async Task<List<CategoryViewModel>> SetTargetRoutes(List<CategoryViewModel> categories)
    {
        var targets = await ApplicationDbContext.Targets.ToListAsync();

        foreach (var category in categories)
        {
            if (targets.Any(t => t.OriginCategoryId == category.Id))
            {
                var destinationCategoryId = targets.Where(t => t.OriginCategoryId == category.Id).Select(t => t.DestinationCategoryId).Single();

                var route = await GetTargetRoute(destinationCategoryId);

                category.Route = route;
            }
        }

        return categories;
    }

    public async Task<List<Domain.Entities.Category.Category>> ReplaceCategoryContent(List<Domain.Entities.Category.Category> categories, int cityId)
    {
        var categoriesCityContents = await ApplicationDbContext.CategoriesCityContents.ToListAsync();

        foreach (var category in categories)
        {
            if (categoriesCityContents.Any(t => t.CategoryId == category.Id && t.CityId == cityId))
            {
                var content = categoriesCityContents
                    .Where(t => t.CategoryId == category.Id && t.CityId == cityId)
                    .Select(t => t.Content)
                    .Single();

                category.PageContent = content;
            }
        }

        return categories;
    }

    public async Task<string?> ReplaceCategoryContent(Domain.Entities.Category.Category category, int cityId)
    {
        var categoriesCityContents = await ApplicationDbContext.CategoriesCityContents
            .Where(c => c.CategoryId == category.Id && c.CityId == cityId).FirstOrDefaultAsync();

        if (categoriesCityContents != null)
        {
            return categoriesCityContents.Content;
        }

        return category.PageContent;
    }

    public async Task<string> SetCategoryPicture(Domain.Entities.Category.Category category)
    {
        if (category.NodeLevel > 1 && string.IsNullOrWhiteSpace(category.Picture))
        {
            int node = category.NodeLevel;
            int parent = category.ParentId;
            List<Domain.Entities.Category.Category> parents = new();
            while (node > 1)
            {
                var c = await ApplicationDbContext.Category
                    .FromSqlInterpolated($"select * from dbo.Category where Id={parent} and IsActive=1")
                    .AsNoTracking().SingleAsync();

                parents.Add(c);
                node = c.NodeLevel;
                parent = c.ParentId;
            }

            parents = parents.OrderBy(a => a.NodeLevel).ToList();

            return parents.FirstOrDefault(a => a.NodeLevel >= 2 && !string.IsNullOrWhiteSpace(a.Picture))?.Picture ?? category.Picture;
        }

        return category.Picture;
    }

    public CategoriesFilterViewModel GetByAdminFilter(CategoriesFilterViewModel filter)
    {
        var query =
          ApplicationDbContext.Category
              .OrderByDescending(b => b.CreateDate)
              .AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Route))
        {
            query = query.Where(a => a.Route.Contains(filter.Route.ToSlug().Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(a => a.Name.Contains(filter.Name.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.PageContent))
        {
            query = query.Where(a => a.PageContent.Contains(filter.PageContent.Trim()));
        }

        //node
        query = filter.NodeLevel != null ? query.Where(a => a.NodeLevel == filter.NodeLevel) : query.Where(a => a.NodeLevel == 1);

        //parent
        query = filter.ParentId != null ? query.Where(a => a.ParentId == filter.ParentId) : query.Where(a => a.ParentId == 0);

        //is active
        query = filter.IsActive != null ? query.Where(a => a.IsActive == filter.IsActive) : query.Where(a => a.IsActive == true);
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }

    public async Task<List<Domain.Entities.Category.Category>> GetChildCategories(int nodeLevel, int parentId)
    {
        var categories =
            await ApplicationDbContext.Category.Where(c =>
                c.ParentId == parentId && c.NodeLevel == nodeLevel && c.IsActive).ToListAsync();

        return categories;
    }
}
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.MainSlider.Repositories;

public class MainSliderRepository : Repository<Domain.Entities.MainSlider.MainSlider>, IMainSliderRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal MainSliderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByJobBranchId(string jobBranchId, int take)
    {
        var mainSliders = await ApplicationDbContext.MainSlider.AsNoTracking()
            .Where(m => m.JobBranchId == jobBranchId)
            .Take(take)
            .ToListAsync();

        return mainSliders;
    }

    public async Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByStateId(int stateId, int take)
    {
        var mainSliders = await ApplicationDbContext.MainSlider.AsNoTracking()
            .Where(m => m.StateId == stateId)
            .Take(take)
            .ToListAsync();

        return mainSliders;
    }

    public async Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByCityId(int cityId, int take)
    {
        var mainSliders = await ApplicationDbContext.MainSlider.AsNoTracking()
            .Where(m => m.CityId == cityId)
            .Take(take)
            .ToListAsync();

        return mainSliders;
    }

    public MainSliderFilterViewModel GetByFilterAdmin(MainSliderFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.MainSlider.OrderByDescending(b => b.Date).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title));
        }

        if (!string.IsNullOrWhiteSpace(filter.LinkPage))
        {
            query = query.Where(a => a.LinkPage.Contains(filter.LinkPage.Trim()));
        }

        if (filter.CityId != null)
        {
            query = query.Where(a => a.CityId == filter.CityId);
        }

        if (filter.StateId != null)
        {
            query = query.Where(a => a.StateId == filter.StateId);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
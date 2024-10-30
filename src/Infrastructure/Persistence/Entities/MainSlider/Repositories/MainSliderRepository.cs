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
}
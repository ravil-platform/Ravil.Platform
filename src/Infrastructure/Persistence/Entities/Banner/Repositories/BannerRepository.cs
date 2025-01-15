using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Banner.Repositories;

public class BannerRepository : Repository<Domain.Entities.Banner.Banner>, IBannerRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal BannerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public BannerFilterViewModel GetByFilter(BannerFilterViewModel filter)
    {
        var query = ApplicationDbContext.Banner.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Banner.Repositories
{
    public interface IBannerRepository : IRepository<Domain.Entities.Banner.Banner>
    {
        BannerFilterViewModel GetByFilter(BannerFilterViewModel filter);
    }
}

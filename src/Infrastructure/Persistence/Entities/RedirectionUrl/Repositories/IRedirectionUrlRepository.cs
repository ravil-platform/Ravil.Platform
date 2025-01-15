using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.RedirectionUrl.Repositories
{
    public interface IRedirectionUrlRepository : IRepository<Domain.Entities.RedirectionUrl.RedirectionUrl>
    {
        RedirectionUrlFilterViewModel GetByFilterAdmin(RedirectionUrlFilterViewModel filter);
    }
}

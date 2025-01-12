using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.ContactUs.Repositories
{
    public interface IContactusRepository : IRepository<Domain.Entities.ContactUs.ContactUs>
    {
        ContactFormFilterAdminViewModel GetByFilter(ContactFormFilterAdminViewModel filter);
    }
}

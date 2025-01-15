using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.ContactUs.Repositories;

public class ContactusRepository : Repository<Domain.Entities.ContactUs.ContactUs>, IContactusRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal ContactusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public ContactFormFilterAdminViewModel GetByFilter(ContactFormFilterAdminViewModel filter)
    {
        var query = ApplicationDbContext.ContactUs.OrderByDescending(a => a.CreateDate).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.FullName))
        {
            query = query.Where(a => a.FullName.Contains(filter.FullName.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
        {
            query = query.Where(a => a.PhoneNumber.Contains(filter.PhoneNumber.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Description))
        {
            query = query.Where(a => a.Message.Contains(filter.Description.Trim()));
        }

        if (filter.IsRead != null)
        {
            query = query.Where(a => a.IsReadByAdmin == filter.IsRead);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
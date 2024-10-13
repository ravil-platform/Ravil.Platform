namespace Persistence.Entities.ContactUs.Repositories;

public class ContactusRepository : Repository<Domain.Entities.ContactUs.ContactUs>, IContactusRepository
{
    internal ContactusRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
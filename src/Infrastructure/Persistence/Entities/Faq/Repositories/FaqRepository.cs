namespace Persistence.Entities.Faq.Repositories;

public class FaqRepository : Repository<Domain.Entities.Faq.Faq>, IFaqRepository
{
    internal FaqRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
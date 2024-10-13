namespace Persistence.Entities.Faq.Repositories;

public class FaqCategoryRepository : Repository<FaqCategory>, IFaqCategoryRepository
{
    internal FaqCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
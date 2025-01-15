namespace Persistence.Entities.Faq.Repositories;

public class FaqJobCategoryRepository : Repository<FaqJobCategory>, IFaqJobCategoryRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }

    internal FaqJobCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
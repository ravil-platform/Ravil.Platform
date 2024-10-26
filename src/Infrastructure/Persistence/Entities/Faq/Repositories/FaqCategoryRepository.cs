namespace Persistence.Entities.Faq.Repositories;

public class FaqCategoryRepository : Repository<FaqCategory>, IFaqCategoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }

    internal FaqCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<ICollection<FaqCategory>> GetAllParents(CancellationToken cancellationToken)
    {
        var model = await
            ApplicationDbContext.FaqCategory.Where(f => f.ParentId == 0).ToListAsync(cancellationToken);

        return model;
    }
}
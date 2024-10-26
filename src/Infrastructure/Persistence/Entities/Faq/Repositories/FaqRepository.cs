namespace Persistence.Entities.Faq.Repositories;

public class FaqRepository : Repository<Domain.Entities.Faq.Faq>, IFaqRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }

    internal FaqRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task DeleteAsync(int id)
    {
        var faq = await GetByIdAsync(id);

        if (faq is null) return;

        await DeleteAsync(faq);
    }

    public async Task<ICollection<Domain.Entities.Faq.Faq>> GetAllFaqsAsync()
    {
        var faq = await ApplicationDbContext.Faqs
            .Include(f => f.FaqCategory)
            .ToListAsync();

        return faq;
    }
}
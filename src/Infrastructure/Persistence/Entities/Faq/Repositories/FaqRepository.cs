namespace Persistence.Entities.Faq.Repositories;

public class FaqRepository : Repository<Domain.Entities.Faq.Faq>, IFaqRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }

    internal FaqRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var faq = await GetByIdAsync(id, cancellationToken);

        if (faq is null) return;

        await DeleteAsync(faq, cancellationToken);
    }
}
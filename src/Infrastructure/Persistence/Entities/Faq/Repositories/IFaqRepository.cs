namespace Persistence.Entities.Faq.Repositories;

public interface IFaqRepository : IRepository<Domain.Entities.Faq.Faq>
{
    public Task DeleteAsync(int id, CancellationToken cancellationToken);
}
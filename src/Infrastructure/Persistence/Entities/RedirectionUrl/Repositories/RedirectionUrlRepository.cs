namespace Persistence.Entities.RedirectionUrl.Repositories;

public class RedirectionUrlRepository : Repository<Domain.Entities.RedirectionUrl.RedirectionUrl>,
    IRedirectionUrlRepository
{
    internal RedirectionUrlRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.ShortLink.Repositories;

public class ShortLinkRepository : Repository<Domain.Entities.ShortLink.ShortLink>, IShortLinkRepository
{
    internal ShortLinkRepository(DbContext databaseContext) : base(databaseContext)
    {

    }
}
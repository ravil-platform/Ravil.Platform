namespace Persistence.Entities.Attr.Repositories;

public class AttrAccountRepository : Repository<AttrAccount>, IAttrAccountRepository
{
    internal AttrAccountRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
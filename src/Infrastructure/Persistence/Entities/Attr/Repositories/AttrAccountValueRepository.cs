namespace Persistence.Entities.Attr.Repositories;

public class AttrAccountValueRepository : Repository<AttrAccountValue>, IAttrAccountValueRepository
{
    internal AttrAccountValueRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
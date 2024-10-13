namespace Persistence.Entities.Attr.Repositories;

public class AttrValueRepository : Repository<AttrValue> , IAttrValueRepository
{
    internal AttrValueRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
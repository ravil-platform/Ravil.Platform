namespace Persistence.Entities.Attr.Repositories;

public class AttrRepository : Repository<Domain.Entities.Attr.Attr>, IAttrRepository
{
    internal AttrRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.Attr.Repositories;

public class AttrCategoryRepository : Repository<AttrCategory>, IAttrCategoryRepository
{
    internal AttrCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
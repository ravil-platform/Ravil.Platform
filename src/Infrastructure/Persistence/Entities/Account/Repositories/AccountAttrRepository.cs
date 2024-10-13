namespace Persistence.Entities.Account.Repositories;

public class AccountAttrRepository : Repository<AccountAttr>, IAccountAttrRepository
{
    internal AccountAttrRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
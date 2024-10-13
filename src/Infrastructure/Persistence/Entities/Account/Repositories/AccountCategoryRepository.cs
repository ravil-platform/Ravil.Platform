namespace Persistence.Entities.Account.Repositories;

public class AccountCategoryRepository : Repository<AccountCategory>, IAccountCategoryRepository
{
    internal AccountCategoryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
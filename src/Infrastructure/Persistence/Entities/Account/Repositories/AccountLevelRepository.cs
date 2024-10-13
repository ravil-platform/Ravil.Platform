namespace Persistence.Entities.Account.Repositories;

public class AccountLevelRepository : Repository<AccountLevel>, IAccountLevelRepository
{
    internal AccountLevelRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
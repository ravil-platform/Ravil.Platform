namespace Persistence.Entities.Account.Repositories;

public class AccountRepository : Repository<Domain.Entities.Account.Account>, IAccountRepository
{
    internal AccountRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
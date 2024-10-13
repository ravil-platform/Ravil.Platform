namespace Persistence.Entities.Transaction.Repositories;

public class WalletTransactionRepository : Repository<WalletTransaction>, IWalletTransactionRepository
{
    internal WalletTransactionRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
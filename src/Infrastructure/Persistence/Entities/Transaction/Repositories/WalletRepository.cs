namespace Persistence.Entities.Transaction.Repositories;

public class WalletRepository : Repository<Wallet>, IWalletRepository
{
    internal WalletRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
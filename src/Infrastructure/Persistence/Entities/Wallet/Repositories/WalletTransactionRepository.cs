using Domain.Entities.Wallets;

namespace Persistence.Entities.Wallet.Repositories;

public class WalletTransactionRepository : Repository<WalletTransaction>, IWalletTransactionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public WalletTransactionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
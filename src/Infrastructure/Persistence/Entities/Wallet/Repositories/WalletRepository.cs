namespace Persistence.Entities.Wallet.Repositories;

public class WalletRepository : Repository<Domain.Entities.Wallets.Wallet>, IWalletRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public WalletRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
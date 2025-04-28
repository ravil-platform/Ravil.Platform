using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Wallet.Repositories;

public interface IWalletRepository : IRepository<Domain.Entities.Wallets.Wallet>
{
    WalletFilterViewModel GetByFilter(WalletFilterViewModel filter);
}
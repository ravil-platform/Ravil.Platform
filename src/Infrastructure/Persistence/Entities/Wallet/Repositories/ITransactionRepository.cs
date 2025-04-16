using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Wallet.Repositories
{
    public interface ITransactionRepository : IRepository<Domain.Entities.Wallets.Transaction>
    {
        TransactionFilterViewModel GetByFilter(TransactionFilterViewModel filter);
    }
}

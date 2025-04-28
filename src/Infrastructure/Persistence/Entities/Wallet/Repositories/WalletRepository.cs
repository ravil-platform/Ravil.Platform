using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Wallet.Repositories;

public class WalletRepository : Repository<Domain.Entities.Wallets.Wallet>, IWalletRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public WalletRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public WalletFilterViewModel GetByFilter(WalletFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.Wallet.Include(u => u.ApplicationUser)
                .AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (filter.ApplicationUserId != null)
        {
            query = query.Where(a => a.ApplicationUserId == filter.ApplicationUserId);
        }

        if (filter.InventoryFrom != null)
        {
            query = query.Where(a => a.Inventory >= filter.InventoryFrom);
        }

        if (filter.InventoryTo != null)
        {
            query = query.Where(a => a.Inventory <= filter.InventoryTo);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
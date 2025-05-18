using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Wallet.Repositories;

public class TransactionRepository : Repository<Domain.Entities.Wallets.Transaction>, ITransactionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public TransactionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public TransactionFilterViewModel GetByFilter(TransactionFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.Transaction
                .OrderByDescending(b => b.TransactionDate).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)

        if (filter.WalletId != null)
        {
            query = ApplicationDbContext.WalletTransaction
                .Include(w => w.Transaction)
                .Where(w => w.WalletId == filter.WalletId)
                .Select(w => w.Transaction)
                .AsQueryable();
        }

        if (filter.AuthCode != null)
        {
            query = query.Where(a => a.AuthCode.Equals(filter.AuthCode));
        }

        if (filter.RefId != null)
        {
            query = query.Where(a => a.RefId.Equals(filter.RefId));
        }

        if (filter.TrackingCode != null)
        {
            query = query.Where(a => a.TrackingCode.Equals(filter.TrackingCode));
        }

        if (filter.Status != null)
        {
            query = query.Where(a => a.Status.Equals(filter.Status));
        }

        #region ( Date Time )
        try
        {
            if (filter.From != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.From.Value.Year;
                var month = filter.From.Value.Month;
                var day = filter.From.Value.Day;

                var registerDateFrom = persianCalendar.ToDateTime(year, month, day, 00, 00, 00, 00);

                query = query.Where(a => a.TransactionDate >= registerDateFrom);
            }

            if (filter.To != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.To.Value.Year;
                var month = filter.To.Value.Month;
                var day = filter.To.Value.Day;

                var registerDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.TransactionDate <= registerDateTo);
            }
        }
        catch
        {
        }
        #endregion
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
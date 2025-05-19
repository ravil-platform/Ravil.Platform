using ViewModels.AdminPanel.Filter;
using ViewModels.Filter.User;

namespace Persistence.Entities.Payment.Repositories;

public class PaymentRepository : Repository<Domain.Entities.Payment.Payment>, IPaymentRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public PaymentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public PaymentFilterViewModel GetByFilter(PaymentFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.Payment
                .OrderByDescending(b => b.PaymentDate).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (filter.PromotionCodeId != null)
        {
            query = query.Where(a => a.PromotionCodeId.Equals(filter.PromotionCodeId));
        }

        if (filter.PaymentPortalId != null)
        {
            query = query.Where(a => a.PaymentPortalId.Equals(filter.PaymentPortalId));
        }

        if (filter.UserId != null)
        {
            query = query.Include(q => q.UserSubscription).ThenInclude(q => q.User);

            query = query.Where(a => a.UserSubscription.User.Id == filter.UserId);
        }

        if (filter.Number != null)
        {
            query = query.Where(a => a.Number == filter.Number);
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

                query = query.Where(a => a.PaymentDate >= registerDateFrom);
            }

            if (filter.To != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.To.Value.Year;
                var month = filter.To.Value.Month;
                var day = filter.To.Value.Day;

                var registerDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.PaymentDate <= registerDateTo);
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
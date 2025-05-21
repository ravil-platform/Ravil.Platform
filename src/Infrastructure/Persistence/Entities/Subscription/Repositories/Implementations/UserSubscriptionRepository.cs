using System.Text.RegularExpressions;
using Domain.Entities.Subscription;
using Persistence.Entities.Subscription.Repositories.Interfaces;
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class UserSubscriptionRepository : Repository<UserSubscription>, IUserSubscriptionRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal UserSubscriptionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }


    public UserSubscriptionFilterViewModel GetByFilter(UserSubscriptionFilterViewModel filter)
    {
        var query =
         ApplicationDbContext.UserSubscription.Include(u => u.User)
             .Include(u => u.Subscription)
             .OrderByDescending(u=> u.StartDate)
             .AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (filter.SubscriptionId != null)
        {
            query = query.Where(a => a.SubscriptionId == filter.SubscriptionId);
        }

        try
        {
            if (filter.From != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.From.Value.Year;
                var month = filter.From.Value.Month;
                var day = filter.From.Value.Day;

                var createdDateFrom = persianCalendar.ToDateTime(year, month, day, 00, 00, 00, 00);

                query = query.Where(a => a.StartDate >= createdDateFrom);
            }

            if (filter.To != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.To.Value.Year;
                var month = filter.To.Value.Month;
                var day = filter.To.Value.Day;

                var createdDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.StartDate <= createdDateTo);
            }
        }
        catch
        {

        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
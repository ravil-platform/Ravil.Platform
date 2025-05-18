using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.MessageBox.Repositories;

public class MessageBoxRepository : Repository<Domain.Entities.MessageBox.MessageBox>, IMessageBoxRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal MessageBoxRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public MessageBoxFilterViewModel GetByFilter(MessageBoxFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.MessageBox
                .Include(m => m.Job)
                .OrderByDescending(b => b.CreateDate)
                .AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (filter.IsRead != null)
        {
            query = query.Where(a => a.IsRead == filter.IsRead);
        }

        if (filter.Type != null)
        {
            query = query.Where(a => a.Type == filter.Type);
        }

        if (filter.JobId != null)
        {
            query = query.Where(a => a.JobId == filter.JobId);
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

                query = query.Where(a => a.CreateDate >= registerDateFrom);
            }

            if (filter.To != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.To.Value.Year;
                var month = filter.To.Value.Month;
                var day = filter.To.Value.Day;

                var registerDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.CreateDate <= registerDateTo);
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
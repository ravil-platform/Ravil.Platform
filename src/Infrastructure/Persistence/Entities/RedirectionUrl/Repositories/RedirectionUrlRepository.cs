using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.RedirectionUrl.Repositories;

public class RedirectionUrlRepository : Repository<Domain.Entities.RedirectionUrl.RedirectionUrl>,
    IRedirectionUrlRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal RedirectionUrlRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public RedirectionUrlFilterViewModel GetByFilterAdmin(RedirectionUrlFilterViewModel filter)
    {
        var query = ApplicationDbContext.RedirectionUrl.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.LatestUrl))
        {
            query = query.Where(a => a.LatestUrl.Contains(filter.LatestUrl));
        }

        if (!string.IsNullOrWhiteSpace(filter.DestinationUrl))
        {
            query = query.Where(a => a.DestinationUrl.Contains(filter.DestinationUrl));
        }

        if (filter.RedirectionType != null)
        {
            query = query.Where(a => a.RedirectionType == filter.RedirectionType);
        }

        if (filter.Status != null)
        {
            query = query.Where(a => a.Status == filter.Status);
        }
        else
        {
            query = query.Where(a => a.Status == true);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
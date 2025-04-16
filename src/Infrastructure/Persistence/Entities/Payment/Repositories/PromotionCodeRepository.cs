using Domain.Entities.Payment;
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Payment.Repositories;

public class PromotionCodeRepository : Repository<PromotionCode>, IPromotionCodeRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal PromotionCodeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public PromotionCodeFilterViewModel GetByFilter(PromotionCodeFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.PromotionCode
                .OrderByDescending(b => b.CreateDate).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Code))
        {
            query = query.Where(a => a.Code.Contains(filter.Code.Trim()));
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
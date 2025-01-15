using Microsoft.IdentityModel.Tokens;
using ViewModels.Filter.Faq;

namespace Persistence.Entities.Faq.Repositories;

public class FaqCategoryRepository : Repository<FaqCategory>, IFaqCategoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }

    internal FaqCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<ICollection<FaqCategory>> GetAllParents(CancellationToken cancellationToken)
    {
        var model = await
            ApplicationDbContext.FaqCategory.Where(f => f.ParentId == 0).ToListAsync(cancellationToken);

        return model;
    }

    public FaqCategoryFilterViewModel GetByFilterAdmin(FaqCategoryFilterViewModel filter)
    {

        var query = ApplicationDbContext.FaqCategory
            .OrderBy(b => b.Sort).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region ( Filters )
        #region ( Categories )
        if (filter.ParentId != null)
        {
            query = query.Where(q => q.ParentId == filter.ParentId);
        }
        else
        {
            query = query.Where(q => q.ParentId == 0);
        }
        #endregion

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(q => q.Title.Contains(filter.Title));
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
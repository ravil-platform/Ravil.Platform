using ViewModels.Filter.Faq;

namespace Persistence.Entities.Faq.Repositories;

public class FaqRepository : Repository<Domain.Entities.Faq.Faq>, IFaqRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }

    internal FaqRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task DeleteAsync(int id)
    {
        var faq = await GetByIdAsync(id);

        if (faq is null) return;

        await DeleteAsync(faq);
    }

    public async Task<ICollection<Domain.Entities.Faq.Faq>> GetAllFaqsAsync()
    {
        var faq = await ApplicationDbContext.Faqs
            .Include(f => f.FaqCategory)
            .ToListAsync();

        return faq;
    }

    public FaqFilterViewModel GetByFilterAdmin(FaqFilterViewModel filter)
    {
        var query = ApplicationDbContext.Faqs.Include(f => f.FaqCategory)
            .OrderBy(b => b.Sort).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region ( Filters )
        #region ( Question )
        if (!string.IsNullOrWhiteSpace(filter.Question))
        {
            query = query.Where(q => q.Question.Contains(filter.Question));
        }
        #endregion

        #region ( Answer )
        if (!string.IsNullOrWhiteSpace(filter.Answer))
        {
            query = query.Where(q => q.Answer.Contains(filter.Answer));
        }
        #endregion

        #region ( Categories )
        if (filter.CategoryId != null)
        {
            query = query.Where(q => q.FaqCategory.Id == filter.CategoryId);
        }
        #endregion
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}
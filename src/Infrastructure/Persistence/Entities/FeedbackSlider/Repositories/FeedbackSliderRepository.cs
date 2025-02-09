using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.FeedbackSlider.Repositories;

public class FeedbackSliderRepository : Repository<Domain.Entities.FeedbackSlider.FeedbackSlider>,
    IFeedbackSliderRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal FeedbackSliderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public FeedbackSliderFilterViewModel GetByFilterAdmin(FeedbackSliderFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.FeedbackSlider.OrderByDescending(b => b.Sort).AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Description))
        {
            query = query.Where(a => a.Description.Contains(filter.Description));
        }

        if (!string.IsNullOrWhiteSpace(filter.UserName))
        {
            query = query.Where(a => a.UserName.Contains(filter.UserName));
        }

        if (filter.CategoryId != null)
        {
            query = query.Where(a => a.CategoryId == filter.CategoryId);
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }

    public async Task<List<Domain.Entities.FeedbackSlider.FeedbackSlider>> GetAllByFilter(int take, int? categoryId = null)
    {
        var model = new List<Domain.Entities.FeedbackSlider.FeedbackSlider>();

        if (categoryId == null)
        {
            model = await ApplicationDbContext.FeedbackSlider.OrderBy(f => f.Sort)
                .AsNoTracking().Take(take).ToListAsync();
        }
        else
        {
            model = await ApplicationDbContext.FeedbackSlider.OrderBy(f => f.Sort)
                .Where(f => f.CategoryId == categoryId).AsNoTracking().Take(take).ToListAsync();
        }

        return model;
    }
}
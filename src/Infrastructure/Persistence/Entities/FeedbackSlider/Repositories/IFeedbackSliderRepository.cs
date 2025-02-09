using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.FeedbackSlider.Repositories
{
    public interface IFeedbackSliderRepository : IRepository<Domain.Entities.FeedbackSlider.FeedbackSlider>
    {
        FeedbackSliderFilterViewModel GetByFilterAdmin(FeedbackSliderFilterViewModel filter);
       Task<List<Domain.Entities.FeedbackSlider.FeedbackSlider>> GetAllByFilter(int take, int? categoryId = null);
    }
}

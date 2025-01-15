using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.FeedbackSlider.Repositories
{
    public interface IFeedbackSliderRepository : IRepository<Domain.Entities.FeedbackSlider.FeedbackSlider>
    {
        FeedbackSliderFilterViewModel GetByFilterAdmin(FeedbackSliderFilterViewModel filter);
    }
}

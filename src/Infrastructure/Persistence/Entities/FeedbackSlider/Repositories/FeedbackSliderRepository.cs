namespace Persistence.Entities.FeedbackSlider.Repositories;

public class FeedbackSliderRepository : Repository<Domain.Entities.FeedbackSlider.FeedbackSlider>,
    IFeedbackSliderRepository
{
    internal FeedbackSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
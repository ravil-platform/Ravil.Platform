namespace Persistence.Entities.User.Repositories;

public class UserFeedbackSliderRepository : Repository<UsersFeedbackSlider>, IUserFeedbackSliderRepository
{
    internal UserFeedbackSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
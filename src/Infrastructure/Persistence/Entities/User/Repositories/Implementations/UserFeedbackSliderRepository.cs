namespace Persistence.Entities.User.Repositories.Implementations;

public class UserFeedbackSliderRepository : Repository<UsersFeedbackSlider>, IUserFeedbackSliderRepository
{
    internal UserFeedbackSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
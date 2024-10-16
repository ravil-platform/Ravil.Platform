namespace Persistence.Entities.User.Repositories.Implementations;

public class UserBannerViewRepository : Repository<UserBannerView>, IUserBannerViewRepository
{
    internal UserBannerViewRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
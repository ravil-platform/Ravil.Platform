namespace Persistence.Entities.User.Repositories;

public class UserBannerViewRepository : Repository<UserBannerView>, IUserBannerViewRepository
{
    internal UserBannerViewRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
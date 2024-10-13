namespace Persistence.Entities.User.Repositories;

public class UserBannerClickRepository : Repository<UserBannerClick>, IUserBannerClickRepository
{
    internal UserBannerClickRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
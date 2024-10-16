namespace Persistence.Entities.User.Repositories.Implementations;

public class UserBannerClickRepository : Repository<UserBannerClick>, IUserBannerClickRepository
{
    internal UserBannerClickRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
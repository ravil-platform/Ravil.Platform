namespace Persistence.Entities.User.Repositories.Implementations;

public class UserBlogLikeRepository : Repository<UserBlogLike>, IUserBlogLikeRepository
{
    internal UserBlogLikeRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.User.Repositories;

public class UserBlogLikeRepository : Repository<UserBlogLike>, IUserBlogLikeRepository
{
    internal UserBlogLikeRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
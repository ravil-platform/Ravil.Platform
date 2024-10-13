namespace Persistence.Entities.User.Repositories;

public class UserBookMarkRepository : Repository<UserBookMark>, IUserBookMarkRepository
{
    internal UserBookMarkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
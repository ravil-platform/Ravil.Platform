namespace Persistence.Entities.User.Repositories.Implementations;

public class UserBookMarkRepository : Repository<UserBookMark>, IUserBookMarkRepository
{
    internal UserBookMarkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
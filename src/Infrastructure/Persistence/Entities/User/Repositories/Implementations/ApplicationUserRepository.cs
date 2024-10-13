namespace Persistence.Entities.User.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    internal ApplicationUserRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
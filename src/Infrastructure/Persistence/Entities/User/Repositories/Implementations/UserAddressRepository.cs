namespace Persistence.Entities.User.Repositories.Implementations;

public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
{
    internal UserAddressRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
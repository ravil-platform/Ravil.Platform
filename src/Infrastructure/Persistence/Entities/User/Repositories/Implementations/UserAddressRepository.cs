namespace Persistence.Entities.User.Repositories;

public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
{
    internal UserAddressRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
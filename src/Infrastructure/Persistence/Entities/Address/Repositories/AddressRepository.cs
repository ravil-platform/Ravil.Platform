namespace Persistence.Entities.Address.Repositories;

public class AddressRepository : Repository<Domain.Entities.Account.Account>, IAddressRepository
{
    public AddressRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
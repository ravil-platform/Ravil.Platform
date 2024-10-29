namespace Persistence.Entities.Address.Repositories;

public class AddressRepository : Repository<Domain.Entities.Address.Address>, IAddressRepository
{
    public AddressRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
namespace Persistence.Entities.Order.Repositories;

public class OrderRepository : Repository<Domain.Entities.Order.Order>, IOrderRepository
{
    internal OrderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
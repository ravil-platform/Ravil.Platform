namespace Persistence.Entities.PaymentPortal.Repositories;

public class PaymentPortalRepository : Repository<Domain.Entities.PaymentPortal.PaymentPortal>,
    IPaymentPortalRepository
{
    internal PaymentPortalRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
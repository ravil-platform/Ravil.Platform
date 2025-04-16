namespace Persistence.Entities.PaymentPortal.Repositories;

public class PaymentPortalRepository : Repository<Domain.Entities.Payment.PaymentPortal>,
    IPaymentPortalRepository
{
    internal PaymentPortalRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
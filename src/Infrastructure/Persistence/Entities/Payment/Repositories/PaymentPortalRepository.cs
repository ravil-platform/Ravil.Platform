namespace Persistence.Entities.Payment.Repositories;

public class PaymentPortalRepository : Repository<Domain.Entities.Payment.PaymentPortal> , IPaymentPortalRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    public PaymentPortalRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
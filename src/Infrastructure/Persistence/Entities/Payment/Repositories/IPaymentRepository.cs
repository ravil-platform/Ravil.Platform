using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Payment.Repositories;

public interface IPaymentRepository : IRepository<Domain.Entities.Payment.Payment>
{
    PaymentFilterViewModel GetByFilter(PaymentFilterViewModel filter);
}
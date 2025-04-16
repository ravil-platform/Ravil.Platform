using Domain.Entities.Payment;
using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Payment.Repositories;

public interface IPromotionCodeRepository : IRepository<PromotionCode>
{
    PromotionCodeFilterViewModel GetByFilter(PromotionCodeFilterViewModel filter);
}
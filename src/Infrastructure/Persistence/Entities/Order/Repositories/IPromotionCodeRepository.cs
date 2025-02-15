using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Order.Repositories;

public interface IPromotionCodeRepository : IRepository<PromotionCode>
{
    PromotionCodeFilterViewModel GetByFilter(PromotionCodeFilterViewModel filter);
}
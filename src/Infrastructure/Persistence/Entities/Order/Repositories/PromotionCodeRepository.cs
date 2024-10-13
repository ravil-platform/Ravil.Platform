namespace Persistence.Entities.Order.Repositories;

public class PromotionCodeRepository : Repository<PromotionCode>, IPromotionCodeRepository
{
    internal PromotionCodeRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
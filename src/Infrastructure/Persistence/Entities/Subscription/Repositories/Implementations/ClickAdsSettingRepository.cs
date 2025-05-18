namespace Persistence.Entities.Subscription.Repositories.Implementations;

public class ClickAdsSettingRepository : Repository<ClickAdsSetting>, IClickAdsSettingRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal ClickAdsSettingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}
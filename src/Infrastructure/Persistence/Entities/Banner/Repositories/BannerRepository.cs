namespace Persistence.Entities.Banner.Repositories;

public class BannerRepository : Repository<Domain.Entities.Banner.Banner>, IBannerRepository
{
    internal BannerRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
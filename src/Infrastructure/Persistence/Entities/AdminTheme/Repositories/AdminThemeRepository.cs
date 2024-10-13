namespace Persistence.Entities.AdminTheme.Repositories;

public class AdminThemeRepository : Repository<Domain.Entities.Account.Account>, IAdminThemeRepository
{
    public AdminThemeRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}
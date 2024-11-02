namespace Persistence.Entities.Config.Repositories;

public class ConfigRepository : Repository<Domain.Entities.Config.Config>, IConfigRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }

    internal ConfigRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<Domain.Entities.Config.Config> GetFirstAsync()
    {
        var result = await ApplicationDbContext.Config.FirstAsync();

        return result;
    }
}
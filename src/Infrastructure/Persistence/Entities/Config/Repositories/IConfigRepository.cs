namespace Persistence.Entities.Config.Repositories
{
    public interface IConfigRepository : IRepository<Domain.Entities.Config.Config>
    {
        Task<Domain.Entities.Config.Config> GetFirstAsync();
    }
}

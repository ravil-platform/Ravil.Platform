namespace RNX.Persistence
{
    public interface IQueryRepository<T> where T : Domain.IEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IList<T>> GetAllAsync();
    }
}

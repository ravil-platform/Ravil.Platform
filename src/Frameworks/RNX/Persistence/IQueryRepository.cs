namespace RNX.Persistence
{
    public interface IQueryRepository<T> where T : Domain.IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}

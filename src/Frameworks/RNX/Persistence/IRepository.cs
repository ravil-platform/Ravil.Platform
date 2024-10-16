namespace RNX.Persistence
{
    public interface IRepository<T> : IQueryRepository<T> where T : Domain.IEntity
    {
        Task InsertAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);

        Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

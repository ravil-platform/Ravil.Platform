namespace RNX.Persistence
{
    public interface IRepository<T> : IQueryRepository<T> where T : Domain.IEntity
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task AttachAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> DeleteByIdAsync(Guid id);
        
        Task InsertRangeAsync(IEnumerable<T> entity);

        Task UpdateRangeAsync(IEnumerable<T> entity);
        
        Task AttachRangeAsync(IEnumerable<T> entity);

        void RemoveRange(IEnumerable<T> entity);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
    }
}

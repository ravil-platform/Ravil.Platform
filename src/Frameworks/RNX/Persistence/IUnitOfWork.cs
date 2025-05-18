namespace RNX.Persistence
{
    public interface IUnitOfWork : IQueryUnitOfWork
    {
        Task<int> SaveAsync();

        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
    }
}

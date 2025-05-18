namespace RNX.Persistence
{
    public abstract class UnitOfWork<T> : QueryUnitOfWork<T>, IUnitOfWork where T : DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        #region ( SaveChanges )

        public async Task<int> SaveAsync()
        {
            return await DatabaseContext.SaveChangesAsync();
        }

        #endregion

        #region ( Transaction )

        public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            await DatabaseContext.Database.BeginTransactionAsync(cancellationToken: cancellationToken);
        }

        public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            await DatabaseContext.Database.CommitTransactionAsync(cancellationToken: cancellationToken);
        }

        public virtual async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            if (DatabaseContext.Database.CurrentTransaction != null)
            {
                await DatabaseContext.Database.RollbackTransactionAsync(cancellationToken: cancellationToken);
            }
        }

        #endregion
    }
}

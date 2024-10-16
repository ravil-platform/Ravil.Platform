namespace RNX.Persistence
{
    public abstract class Repository<T> :
        object, IRepository<T> where T : class, Domain.IEntity
    {
        protected internal Repository(DbContext databaseContext) : base()
        {
            DatabaseContext =
                databaseContext ??
                throw new ArgumentNullException(paramName: nameof(databaseContext));

            DbSet = DatabaseContext.Set<T>();
        }

        protected DbSet<T> DbSet { get; }

        protected DbContext DatabaseContext { get; }


        public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity, cancellationToken);
        }

        protected virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            }, cancellationToken);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            }, cancellationToken);
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id.ToString(), cancellationToken);
        }
        
        public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id.ToString(), cancellationToken);
        }

        public virtual async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            T entity = await GetByIdAsync(id, cancellationToken);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity, cancellationToken);

            return true;
        }

        public virtual async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await DbSet.ToListAsync(cancellationToken);

            return result;
        }
    }
}

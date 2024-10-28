using System.Linq.Expressions;

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

        public virtual IQueryable<T> Table => DbSet;
        public virtual IQueryable<T> TableNoTracking => DbSet.AsNoTracking();


        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);
        }

        protected virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id.ToString());
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).SingleOrDefaultAsync();

            return result;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).ToListAsync();

            return result;
        }

        public virtual async Task<bool> DeleteByIdAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity);

            return true;
        }

        public virtual async Task<ICollection<T?>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync();

            return result;
        }
    }
}

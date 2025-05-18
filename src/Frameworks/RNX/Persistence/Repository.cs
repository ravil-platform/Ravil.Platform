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

        public virtual async Task AttachAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Attach(entity);
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

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).SingleOrDefaultAsync();

            return result;
        }

        public virtual async Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate, string includes = "")
        {
            var result = DbSet.AsNoTracking().Where(predicate);

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    result = result.Include(include);
                }
            }

            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).ToListAsync();

            return result;
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = "", int? takeEntities = null)
        {
            var query = DbSet.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);

            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            if (takeEntities != null)
            {
                return await query.Take((int)takeEntities).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int takeEntities)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).Take(takeEntities).ToListAsync();

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

        public async Task InsertRangeAsync(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddRangeAsync(entity);
        }
        
        public async Task UpdateRangeAsync(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.UpdateRange(entity);
            });
        }
        
        public async Task AttachRangeAsync(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.AttachRange(entity);
            });
        }

        public virtual void RemoveRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }

        public virtual async Task BeginTransactionAsync()
        {
            await DatabaseContext.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTransactionAsync()
        {
            await DatabaseContext.Database.CommitTransactionAsync();
        }

        public virtual async Task RollBackTransactionAsync()
        {
            await DatabaseContext.Database.RollbackTransactionAsync();
        }

        public virtual async Task<ICollection<T?>> GetAllAsync()
        {
            var result = await DbSet.AsNoTracking().ToListAsync();

            return result;
        }
    }
}

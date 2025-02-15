using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RNX.Persistence
{
    public abstract class QueryRepository<TEntity> :
        object, IQueryRepository<TEntity> where TEntity : class, Domain.IEntity
    {
        protected QueryRepository(DbContext databaseContext) : base()
        {
            DatabaseContext = databaseContext ??
                              throw new ArgumentNullException(paramName: nameof(databaseContext));

            DbSet = DatabaseContext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        protected DbContext DatabaseContext { get; }

        public virtual IQueryable<TEntity> Table => DbSet;
        public virtual IQueryable<TEntity> TableNoTracking => DbSet.AsNoTracking();


        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity?> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity?> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).SingleOrDefaultAsync();

            return result;
        }

        public virtual async Task<TEntity?> GetByPredicate(Expression<Func<TEntity, bool>> predicate, string includes = "")
        {
            var result = DbSet.AsNoTracking().Where(predicate);

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    result = result.Include(include);
                }
            }

            return await result.SingleOrDefaultAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).ToListAsync();

            return result;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includes = "", int? takeEntities = null)
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

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, int takeEntities)
        {
            var result = await DbSet.AsNoTracking().Where(predicate).Take(takeEntities).ToListAsync();

            return result;
        }

        public virtual async Task<ICollection<TEntity?>> GetAllAsync()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;

            var result = await DbSet.AsNoTracking().ToListAsync();

            return result;
        }
    }
}

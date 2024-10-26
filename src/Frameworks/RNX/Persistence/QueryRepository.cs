using System.Linq.Expressions;

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


        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity?> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).SingleOrDefaultAsync();

            return result;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).ToListAsync();

            return result;
        }

        public virtual async Task<ICollection<TEntity?>> GetAllAsync()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;

            var result = await DbSet.ToListAsync();

            return result;
        }
    }
}

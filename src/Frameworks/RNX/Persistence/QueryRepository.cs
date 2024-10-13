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
   

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(keyValues: id);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
           
            var result = await DbSet.ToListAsync();

            return result;
        }
    }
}

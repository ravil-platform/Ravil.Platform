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
   

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
           
            var result = await DbSet.ToListAsync(cancellationToken);

            return result;
        }
    }
}

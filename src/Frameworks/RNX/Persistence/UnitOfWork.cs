namespace RNX.Persistence
{
    public abstract class UnitOfWork<T> : QueryUnitOfWork<T>, IUnitOfWork where T : DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        public async Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}

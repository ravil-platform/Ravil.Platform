namespace RNX.Persistence
{
    public abstract class UnitOfWork<T> : QueryUnitOfWork<T>, IUnitOfWork where T : DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        public async Task SaveAsync()
        {
            try
            {
                await DatabaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

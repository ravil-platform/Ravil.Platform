namespace RNX.Persistence
{
    public interface IUnitOfWork : IQueryUnitOfWork
    {
        Task SaveAsync();
    }
}

namespace RNX.Persistence
{
    public interface IQueryUnitOfWork : IDisposable
    {
        bool IsDisposed { get; }
    }
}

namespace RNX.Persistence
{
    public interface IRepository<T> : IQueryRepository<T> where T : Domain.IEntity
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}

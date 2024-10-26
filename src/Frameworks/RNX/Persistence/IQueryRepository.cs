using System.Linq.Expressions;

namespace RNX.Persistence
{
    public interface IQueryRepository<T> where T : Domain.IEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate);

        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T?>> GetAllAsync();
    }
}

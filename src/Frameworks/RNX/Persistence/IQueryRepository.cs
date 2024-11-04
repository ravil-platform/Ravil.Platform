using System.Linq.Expressions;

namespace RNX.Persistence
{
    public interface IQueryRepository<T> where T : Domain.IEntity
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(string id);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate, string includes = "");

        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = "" , int? takeEntities = null);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int takeEntities);
        Task<ICollection<T?>> GetAllAsync();
    }
}

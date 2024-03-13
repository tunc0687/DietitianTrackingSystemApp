using System.Linq.Expressions;

namespace DietitianTrackingSystemApp.Data.Domain.EfCoreRepository
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entity);
        void Update(T entity);
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindListAsNoTrackingAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task<(List<T> Data, long TotalCount)> SearchAsync(IQueryable<T> query, int? pageNumber, int? pageSize);
    }
}
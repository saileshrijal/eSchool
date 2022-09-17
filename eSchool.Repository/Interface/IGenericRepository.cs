using System.Linq.Expressions;

namespace eSchool.Repository.Interface;

public interface IGenericRepository<T> : IDisposable where T:class
{
    IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");

    T GetById(Object id);
    Task<T> GetByIdAsync(Object id);
    void Add(T entity);
    Task<T> AddAsync(T entity);
    void Update(T entity);
    Task<T> UpdateAsync(T entity);
    void Delete(T entity);
    Task<T> DeleteAsync(T entity);
}
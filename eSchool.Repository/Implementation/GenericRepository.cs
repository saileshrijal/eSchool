using System.Linq.Expressions;
using eSchool.Repository.Interface;

namespace eSchool.Repository.Implementation;

public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T:class
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
    {
        throw new NotImplementedException();
    }

    public T GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(object id)
    {
        throw new NotImplementedException();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(object id)
    {
        throw new NotImplementedException();
    }
}
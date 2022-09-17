using eSchool.Repository.Interface;

namespace eSchool.Repository.Implementation;

public class UnitOfWork:IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    private bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this.disposed = true;
    }
    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        IGenericRepository<T> repo = new GenericRepository<T>(_context);
        return repo;
    }

    public void save()
    {
        _context.SaveChanges();
    }
}
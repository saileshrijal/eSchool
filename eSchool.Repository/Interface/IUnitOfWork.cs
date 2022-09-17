namespace eSchool.Repository.Interface;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    void save();
}
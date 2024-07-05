namespace Travelso_Website_Shared.Interfaces.IRepository;

public interface IRepository<T> where T : class
{
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(object? id);
    Task<T?> GetById(object? id);
    Task<IEnumerable<T>?> GetAll();
}
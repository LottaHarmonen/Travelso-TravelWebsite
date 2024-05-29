namespace Travelso_Website_Shared.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>?> GetAll();
    Task<bool> Add(T entity);
    Task<bool> Delete(int id);
    Task<T?> GetById(int id);
    Task<bool> Update(int id, T entity);

}
namespace Travelso_Website_Shared.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Delete(int id);
    Task<T> GetById(int id);
    Task Update(int id, T entity);

}
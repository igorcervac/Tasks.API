namespace Tasks.API.Models;

public interface IRepository<T>: IReadonlyRepository<T> where T : IEntity
{
    Task<T> AddAsync(T entity);
    System.Threading.Tasks.Task UpdateAsync(T entity);
    System.Threading.Tasks.Task DeleteAsync(T entity);
}

namespace Tasks.API.Models
{
    public interface IGenericRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        System.Threading.Tasks.Task UpdateAsync(T entity);
        System.Threading.Tasks.Task DeleteAsync(T entity);
    }
}

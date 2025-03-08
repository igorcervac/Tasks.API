namespace Tasks.API.Models;

public interface IReadonlyRepository<T> where T : IEntity
{    IEnumerable<T> GetAll();
    Task<T> GetByIdAsync(int id);
}


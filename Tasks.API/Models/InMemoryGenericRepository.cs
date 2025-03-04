namespace Tasks.API.Models
{
    public class InMemoryGenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        public static List<T> _objects = new List<T>();

        public async Task<T> AddAsync(T entity)
        {
            _objects.Add(entity);
            return await System.Threading.Tasks.Task.FromResult(entity);
        }

        public async System.Threading.Tasks.Task DeleteAsync(T entity)
        {
            _objects.Remove(entity);
            await System.Threading.Tasks.Task.Delay(0);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await System.Threading.Tasks.Task.FromResult(_objects);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var @object = _objects.Find(x => x.Id == id);
            return await System.Threading.Tasks.Task.FromResult(@object);
        }

        public async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            await System.Threading.Tasks.Task.Delay(0);
        }
    }
}

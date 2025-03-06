namespace Tasks.API.Models
{
    public abstract class InMemoryGenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected static List<T> _objects = new List<T>();

        public async Task<T> AddAsync(T entity)
        {
            var maxId = _objects.Any() ? _objects.Max(x => x.Id) : 0;
            entity.Id = maxId + 1;
            _objects.Add(entity);
            return await System.Threading.Tasks.Task.FromResult(entity);
        }

        public async System.Threading.Tasks.Task DeleteAsync(T entity)
        {
            _objects.Remove(entity);
            await System.Threading.Tasks.Task.Delay(0);
        }

        public IEnumerable<T> GetAll()
        {
            return _objects;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var @object = _objects.Find(x => x.Id == id);
            return await System.Threading.Tasks.Task.FromResult(@object);
        }

        public abstract System.Threading.Tasks.Task UpdateAsync(T entity);
    }
}

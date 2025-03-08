namespace Tasks.API.Models
{
    public abstract class InMemoryRepository<T> : InMemoryReadonlyRepository<T>, IRepository<T>
        where T : IEntity
    {
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

        public abstract System.Threading.Tasks.Task UpdateAsync(T entity);
    }
}

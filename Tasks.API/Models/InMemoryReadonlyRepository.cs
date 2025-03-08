namespace Tasks.API.Models
{
    public class InMemoryReadonlyRepository<T>: IReadonlyRepository<T> where T: IEntity
    {
        protected static List<T> _objects = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _objects;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var @object = _objects.Find(x => x.Id == id);
            return await System.Threading.Tasks.Task.FromResult(@object);
        }

    }
}

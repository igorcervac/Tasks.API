namespace Tasks.API.Models
{
    public class InMemoryStateRepository: InMemoryReadonlyRepository<State>, IReadonlyRepository<State>
    {
        public InMemoryStateRepository()
        {
            _objects = new List<State>
            {
                new() { Id = 1, Name = "Not Started" },
                new() { Id = 2, Name = "In Progress" },
                new() { Id = 3, Name = "Completed" },
            };
        }
    }
}

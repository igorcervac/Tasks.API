namespace Tasks.API.Models
{
    public class InMemoryTaskRepository : InMemoryRepository<Task>, IRepository<Task>
    {
        public override async System.Threading.Tasks.Task UpdateAsync(Task entity)
        {
            var entityToUpdate = _objects.Find(x => x.Id == entity.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Title = entity.Title;
                entityToUpdate.Description = entity.Description;
                entityToUpdate.StateId = entity.StateId;
            }
            await System.Threading.Tasks.Task.Delay(0);
        }
    }
}

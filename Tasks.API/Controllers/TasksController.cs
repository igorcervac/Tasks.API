using Microsoft.AspNetCore.Mvc;
using Tasks.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<Models.Task> _taskRepository;

        public TasksController(IRepository<Models.Task> repository)
        {
            _taskRepository = repository ?? throw new ArgumentNullException();
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            return _taskRepository.GetAll();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<Models.Task> Get(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<Models.Task> Post([FromBody] Models.Task task)
        {
            return await _taskRepository.AddAsync(task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task Put(int id, [FromBody] Models.Task task)
        {
            await _taskRepository.UpdateAsync(task);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task Delete(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            await _taskRepository.DeleteAsync(task);
        }
    }
}

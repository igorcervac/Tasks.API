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
        public ActionResult<IEnumerable<Models.Task>> Get()
        {
            return Ok(_taskRepository.GetAll());
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<ActionResult<Models.Task>> Post([FromBody] Models.Task task)
        {
            var createdTask = await _taskRepository.AddAsync(task);
            return CreatedAtAction(nameof(GetById), new {id =  createdTask.Id}, createdTask);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var taskToUpdate = await _taskRepository.GetByIdAsync(id);

            if (taskToUpdate == null)
            {
                return NotFound(); 
            }

            await _taskRepository.UpdateAsync(task);

            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            await _taskRepository.DeleteAsync(task);

            return NoContent();
        }
    }
}

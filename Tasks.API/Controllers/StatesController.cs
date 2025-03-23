using Microsoft.AspNetCore.Mvc;
using Tasks.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IReadonlyRepository<State> _stateRepository;

        public StatesController(IReadonlyRepository<State> stateRepository)
        {
            _stateRepository = stateRepository ?? throw new ArgumentNullException();
        }

        // GET: api/<StatesController>
        [HttpGet]
        public ActionResult<IEnumerable<State>> Get()
        {
            return Ok(_stateRepository.GetAll());
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var state = await _stateRepository.GetByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }        
    }
}

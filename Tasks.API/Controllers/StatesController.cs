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
        public IEnumerable<State> Get()
        {
            return _stateRepository.GetAll();
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public async Task<State> Get(int id)
        {
            return await _stateRepository.GetByIdAsync(id);
        }        
    }
}

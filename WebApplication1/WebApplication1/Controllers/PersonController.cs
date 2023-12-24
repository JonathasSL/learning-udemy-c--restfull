using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(PersonService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = PersonService.FindById(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return Ok(PersonService.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            return Ok(PersonService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonService.Delete(id);
            
            return NoContent();
        }

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService PersonService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            PersonService = personService;
        }
    }
}

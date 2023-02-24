using Friday.Repository.Models;
using Friday.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository repository;

        public PersonsController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return await repository.GetPersons();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            return await repository.GetPerson(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            var p = await repository.AddPerson(person);
            return p;
        }

        [HttpPut]
        public async Task<ActionResult<Person>> UpdatePerson(Person person)
        {
            var p = await repository.UpdatePerson(person);

            return p;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var str = await repository.DeletePerson(id);
            return Ok(str);
        }
    }
}

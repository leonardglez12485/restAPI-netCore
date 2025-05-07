using Microsoft.AspNetCore.Mvc;
using TestAPI.Entities;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = FetchPersons();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var persons = FetchPersons();
            var person = persons.Find(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

    private List<Person> FetchPersons()
     {
        List<Person> persons = new List<Person>
         {
        new Person { Id = 1, Name = "John", LastName = "Doe", Age = 30 },
        new Person { Id = 2, Name = "Jane", LastName = "Smith", Age = 25 },
        new Person { Id = 3, Name = "Bob", LastName = "Johnson", Age = 40 }
         };
            return persons;
    }
}
}
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
        new() { Id = 1, Name = "John", LastName = "Doe", Age = 30 },
        new() { Id = 2, Name = "Jane", LastName = "Smith", Age = 25 },
        new() { Id = 3, Name = "Bob", LastName = "Johnson", Age = 40 },
        new() { Id = 4, Name = "Alice", LastName = "Williams", Age = 35 },
        new() { Id = 5, Name = "Charlie", LastName = "Brown", Age = 28 },
        new() { Id = 6, Name = "David", LastName = "Jones", Age = 45 },
        new() { Id = 7, Name = "Eve", LastName = "Davis", Age = 32 },
        new() { Id = 8, Name = "Frank", LastName = "Miller", Age = 50 },
        new() { Id = 9, Name = "Grace", LastName = "Wilson", Age = 29 },
        new() { Id = 10, Name = "Hank", LastName = "Moore", Age = 38 },
         };
            return persons;
    }
}
}
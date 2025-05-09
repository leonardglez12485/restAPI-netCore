using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.DTOs;
using TestAPI.Entities;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContex _context;

        public PersonController(DataContex context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _context.Persons
                .Select(p => new GetPersonDto
                {
                    Name = p.Name,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    IsActive = p.IsActive,
                })
                .ToListAsync();

            if (persons == null || persons.Count == 0)
            {
                return NotFound("No persons found");
            }

            return Ok(persons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound("Person not found");
            }
            var personDto = new GetPersonDto
            {
                Name = person.Name,
                LastName = person.LastName,
                IsActive = person.IsActive,
                BirthDate = person.BirthDate
            };
            return Ok(personDto);
        }

        // private List<Person> FetchPersons()
        // {

        // }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Person cannot be null");
            }
            try
            {
                var person = new Person
                {
                    Name = personDto.Name,
                    LastName = personDto.LastName,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    BirthDate = personDto.BirthDate
                };
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating person: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] EditPersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Invalid person data");
            }
            var existingPerson = await _context.Persons.FirstOrDefaultAsync(pers => pers.Id == id);
            if (existingPerson == null)
            {
                return NotFound("Person not found");
            }
            try
            {
                var dtoProperties = typeof(EditPersonDto).GetProperties();
                var entityProperties = typeof(Person).GetProperties();

                foreach (var dtoProp in dtoProperties)
                {
                    var value = dtoProp.GetValue(personDto);
                    if (value != null)
                    {
                        var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                        if (entityProp != null && entityProp.CanWrite)
                        {
                            entityProp.SetValue(existingPerson, value);
                        }
                    }
                }
                _context.Persons.Update(existingPerson);
                await _context.SaveChangesAsync();
                return Ok(existingPerson);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating person: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound("Person not found");
            }
            try
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return Ok("Person deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting person: {ex.Message}");
            }
        }
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchPersons([FromQuery] string name)
        {
            var persons = await _context.Persons
                .Where(p => p.Name.Contains(name))
                .Select(r => new GetPersonDto
                {
                    Name = r.Name,
                    LastName = r.LastName,
                    IsActive = r.IsActive,
                    BirthDate = r.BirthDate
                })
                .ToListAsync();
            if (persons == null || persons.Count == 0)
            {
                return NotFound("No persons found with the given name");
            }
            return Ok(persons);
        }

    }
}
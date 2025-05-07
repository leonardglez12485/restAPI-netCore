using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello from HomeController!");
        }

         [HttpGet("age")]
         [ProducesResponseType(StatusCodes.Status200OK)] 
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Greet([FromQuery] int? age)
        {
            if (!age.HasValue)
            {
                return BadRequest("Age is required.");
            }
            if (age < 0)
            {
                return BadRequest("Age cannot be negative.");
            }
            if (age > 120)
            {
                return BadRequest("Age is not realistic.");
            }


            int yearOfBirth = DateTime.Now.Year - age.Value;
            return Ok($"You were born in {yearOfBirth}.");
        }
    }
}

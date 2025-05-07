using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello from DemoController!");
        }

        [HttpGet("greet")]
        public IActionResult Greet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be null or empty.");
            }

            return Ok($"Hello, {name}!");
        }
        
    }
}
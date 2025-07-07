using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        // GET: api/calculator/add?x=1&y=2
        [HttpGet("add")]
        public ActionResult<double> Add([FromQuery] double x, [FromQuery] double y)
        {
            return Ok(x + y);
        }

        // GET: api/calculator/subtract?x=5&y=3
        [HttpGet("subtract")]
        public ActionResult<double> Subtract([FromQuery] double x, [FromQuery] double y)
        {
            return Ok(x - y);
        }

        // GET: api/calculator/multiply?x=4&y=6
        [HttpGet("multiply")]
        public ActionResult<double> Multiply([FromQuery] double x, [FromQuery] double y)
        {
            return Ok(x * y);
        }

        // GET: api/calculator/divide?x=10&y=2
        [HttpGet("divide")]
        public ActionResult<double> Divide([FromQuery] double x, [FromQuery] double y)
        {
            if (y == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }
            return Ok(x / y);
        }
    }
} 
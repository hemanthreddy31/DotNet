using DotNet8WebAPI.Helpers;
using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async  Task<IActionResult>Get()
        {
            return Ok(await _userService.GetAll()); 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userObj)
        {
            userObj.Id = 0;
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userObj)
        {
            userObj.Id=id;
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);
            if(response == null) 
                return BadRequest (new { message = "Username or Password is incorrect" });
            return Ok(response);
        }
    }
}

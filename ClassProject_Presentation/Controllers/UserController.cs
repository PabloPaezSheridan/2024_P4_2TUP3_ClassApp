using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassProject_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add([FromQuery] string username, [FromBody] string password)
        {

            _userService.AddUser(new Domain.Entities.User() { Password = password, Name = username });
            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos;

namespace TicketEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUserAccount(CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            await _userService.CreateUserAccount(userDto);
            return Ok();
        }
    }
}

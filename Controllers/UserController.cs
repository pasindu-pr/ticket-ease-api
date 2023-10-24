using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Users;
using TicketEase.Responses;

namespace TicketEase.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("travellers")]
        public async Task<ActionResult<ApiResponse>> GetAllTravellers()
        {
            ApiResponse response = await _userService.GetAllTravellers();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> CreateUserAccount(CreateUserDto userDto)
        {
            if (!ModelState.IsValid || userDto == null)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _userService.CreateUserAccount(userDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("register/traveller")]
        public async Task<ActionResult<ApiResponse>> CreateTravellerAccount(CreateTravellerDto userDto)
        {
            if (!ModelState.IsValid || userDto == null)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _userService.CreateTravellerAccount(userDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login(LoginUserDto userDto)
        {
            if (!ModelState.IsValid || userDto == null)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _userService.LoginAsync(userDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else if (!response.Success && response.Message == "Account is not activated")
            {
                return Unauthorized(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("deactivate")]
        public async Task<ActionResult<ApiResponse>> DeativateAccount()
        {
            ApiResponse response = await _userService.DeactivateAccout();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("activate")]
        public async Task<ActionResult<ApiResponse>> ActivateAccount(ActivateUserAccountDto user)
        {
            ApiResponse response = await _userService.ActivateAccount(user);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}

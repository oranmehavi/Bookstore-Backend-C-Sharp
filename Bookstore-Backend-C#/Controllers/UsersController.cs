using Bookstore_Backend_C_.Models;
using Bookstore_Backend_C_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookstore_Backend_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Signup([FromBody] SignupModel signupModel)
        {
            var result = await _usersRepository.Signup(signupModel);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(new { Data = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _usersRepository.Login(loginModel);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(new { Data = result });
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUserByToken()
        {
            var user = await _usersRepository.GetUserByTokenAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new { Data = new { User = user } });
        }

        [HttpPatch, Authorize]
        public async Task<IActionResult> EditUser([FromBody] EditUserModel editUserModel)
        {
            var user = await _usersRepository.EditUserAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), editUserModel);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new { Data = user });
        }

        [HttpDelete, Authorize] 
        public async Task<IActionResult> DeleteUser()
        {
            var result = await _usersRepository.DeleteUserAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}

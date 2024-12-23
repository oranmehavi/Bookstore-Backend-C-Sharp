using Bookstore_Backend_C_.Models;
using Bookstore_Backend_C_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Backend_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Signup([FromBody] SignupModel signupModel)
        {
            var result = await _accountRepository.Signup(signupModel);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _accountRepository.Login(loginModel);
            if (string.IsNullOrWhiteSpace(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}

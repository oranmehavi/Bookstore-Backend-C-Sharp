using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Bookstore_Backend_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet, Authorize]
        public async Task<IActionResult> GetSub()
        {
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            
            return Ok(sub);
        }
    }
}

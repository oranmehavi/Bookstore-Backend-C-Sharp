using AutoMapper;
using Bookstore_Backend_C_.Data;
using Bookstore_Backend_C_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookstore_Backend_C_.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(BookstoreContext context, IMapper mapper, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Signup(SignupModel signupModel)
        {
            UserModel user = new()
            {
                Fullname = signupModel.Fullname,
                UserName = signupModel.Username,
                Email = signupModel.Email,
            };

            var result = await _userManager.CreateAsync(user, signupModel.Password);
            return result;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            string token = NewToken(loginModel.Email, user.Id);
            return token;
        }

        public async Task<GetUserDTO> GetUserByTokenAsync(string id)
        {
            var user = await _context.Users.Include(u => u.Cart).ThenInclude(c => c.Book).Where(u => u.Id == id).FirstOrDefaultAsync();
            
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<GetUserDTO> EditUserAsync(string id, EditUserModel editUserModel)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            user.Fullname = editUserModel.Fullname;
            user.Email = editUserModel.Email;
            user.UserName = editUserModel.UserName;
            if (editUserModel.NewPassword != null && editUserModel.CurrentPassword != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, editUserModel.CurrentPassword, editUserModel.NewPassword);
                if (!result.Succeeded)
                    return null;
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(user);
        }

        

        private string NewToken(string email, string id)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, id)
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

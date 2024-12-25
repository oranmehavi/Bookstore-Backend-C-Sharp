using Bookstore_Backend_C_.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookstore_Backend_C_.Repositories
{
    public interface IUsersRepository
    {
        Task<IdentityResult> Signup(SignupModel signupModel);
        Task<string> Login(LoginModel loginModel);
        Task<GetUserDTO> GetUserByTokenAsync(string id);
        Task<GetUserDTO> EditUserAsync(string id, EditUserModel editUserModel);

    }
}
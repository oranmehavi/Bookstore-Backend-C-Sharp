using Bookstore_Backend_C_.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookstore_Backend_C_.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Signup(SignupModel signupModel);
        Task<string> Login(LoginModel loginModel);
    }
}
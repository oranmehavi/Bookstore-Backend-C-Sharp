using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Repositories
{
    public interface IUsersRepository
    {
        Task<GetUserWithTokenDTO> Signup(SignupModel signupModel);
        Task<GetUserWithTokenDTO> Login(LoginModel loginModel);
        Task<GetUserDTO> GetUserByTokenAsync(string id);
        Task<GetUserDTO> EditUserAsync(string id, EditUserModel editUserModel);
        Task<bool> DeleteUserAsync(string id);
    }
}
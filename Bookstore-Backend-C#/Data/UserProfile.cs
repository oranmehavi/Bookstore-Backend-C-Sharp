using AutoMapper;
using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Data
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserModel, GetUserDTO>();
        }
    }
}

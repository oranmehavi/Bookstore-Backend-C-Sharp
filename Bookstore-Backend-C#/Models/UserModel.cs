using Microsoft.AspNetCore.Identity;

namespace Bookstore_Backend_C_.Models
{
    public class UserModel : IdentityUser
    {
        public string Fullname { get; set; }
        public IList<CartModel>? Cart { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}

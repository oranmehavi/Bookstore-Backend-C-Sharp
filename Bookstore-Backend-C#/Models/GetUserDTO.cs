namespace Bookstore_Backend_C_.Models
{
    public class GetUserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public IList<CartModel>? Cart { get; set; }
        public bool IsAdmin { get; set; }

    }
}

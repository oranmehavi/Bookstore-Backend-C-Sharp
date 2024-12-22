namespace Bookstore_Backend_C_.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}

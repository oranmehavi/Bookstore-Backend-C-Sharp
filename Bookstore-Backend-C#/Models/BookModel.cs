namespace Bookstore_Backend_C_.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public double Price { get; set; }
        public int Discount { get; set; } = 0;
        public double PriceAfterDiscount { get; set; }
    }
}

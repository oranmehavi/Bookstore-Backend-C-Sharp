namespace Bookstore_Backend_C_.Models
{
    public class GetReturnedBooksDTO
    {
        public IList<BookModel> Books { get; set; }
        public int Length { get; set; }
    }
}

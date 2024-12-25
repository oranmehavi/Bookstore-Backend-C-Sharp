namespace Bookstore_Backend_C_.Models
{
    public class NewCartData
    {
        public bool IsNew {  get; set; }
        public int Index { get; set; }
        public int? NewQuantity { get; set; }
        public GetUserDTO NewUserData { get; set; }

    }
}

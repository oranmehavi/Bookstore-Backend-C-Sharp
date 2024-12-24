namespace Bookstore_Backend_C_.Models
{
    public class BookModel
    {
        private double _price;
        private int _discount;
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Image {  get; set; }
        public double Price 
        { 
            get => _price; 
            set
            {
                _price = value;
                UpdatePriceAfterDiscount();
            } 
        }
        public int Discount 
        { 
            get => _discount; 
            set
            {
                _discount = value;
                UpdatePriceAfterDiscount();
            }
        }
        public double PriceAfterDiscount { get; set; }
        
        private void UpdatePriceAfterDiscount()
        {
            PriceAfterDiscount = Price * (100 - Discount) / 100.0;
        }
    }
}

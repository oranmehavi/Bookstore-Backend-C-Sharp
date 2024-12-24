using System.ComponentModel.DataAnnotations;

namespace Bookstore_Backend_C_.Models
{
    public class NewBookModel
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Image {  get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be at least 1.")]
        public double Price { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
        public int Discount { get; set; }
    }
}

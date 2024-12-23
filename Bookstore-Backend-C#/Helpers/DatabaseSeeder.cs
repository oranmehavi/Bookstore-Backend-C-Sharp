using Bookstore_Backend_C_.Data;
using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Helpers
{
    public static class DatabaseSeeder
    {
        public static async Task SeedBooks(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BookstoreContext>();
            if (!context.Books.Any())
            {
                await context.Books.AddRangeAsync(
                    new BookModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "סודות בית השמפניה",
                        Author = "קריסטין הרמל",
                        Image = "https://images-evrit.yit.co.il/Images/Products/covers_2020/new_winemakers_master.jpg",
                        Description = "סיפור קורע לב על החלטה אחת שמשנה חיים שלמים",
                        Price = 60.5,
                        Discount = 0
                    },
                    new BookModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "המכתב האבוד",
                        Author = "ג'יליאן קנטור",
                        Image = "https://images-evrit.yit.co.il/Images/Products/covers_2018/letter_master(1).jpg",
                        Description = "זהו רומן היסטורי שעלילתו מתפצלת לשני קווים מקבילים, ומתפרשת מאוסטריה שלקראת מלחמת העולם השנייה ועד ללוס אנג’לס של שנות התשעים.",
                        Price = 120,
                        Discount = 50
                    }
                    );

                await context.SaveChangesAsync();
            }
        }
    }
}

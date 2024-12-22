using Bookstore_Backend_C_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Backend_C_.Data
{
    public class BookstoreContext : IdentityDbContext<UserModel>
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<BookModel> Books { get; set; }
    }
}

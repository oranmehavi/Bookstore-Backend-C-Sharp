using AutoMapper;
using Bookstore_Backend_C_.Data;
using Bookstore_Backend_C_.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Backend_C_.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;
        public CartRepository(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NewCartData> AddToCartAsync(string userId, NewCartItem newCartItem)
        {
            var user = await _context.Users.Include(u => u.Cart).ThenInclude(c => c.Book).Where(u => u.Id == userId).FirstOrDefaultAsync();

            var cartItemWithIndex = user.Cart.Select((c, index) => new { Item = c, Index = index })
                                             .FirstOrDefault(c => c.Item.Book.Id.ToString() == newCartItem.Book);

            if (cartItemWithIndex != null)
            {
                cartItemWithIndex.Item.Quantity += newCartItem.Quantity;
                await _context.SaveChangesAsync();
                return new NewCartData
                {
                    IsNew = false,
                    Index = cartItemWithIndex.Index,
                    NewQuantity = cartItemWithIndex.Item.Quantity,
                    NewUserData = _mapper.Map<GetUserDTO>(user)
                };
            }

            var book = await _context.Books.FindAsync(new Guid(newCartItem.Book));
            user.Cart.Add(new CartModel { Id = new Guid(), Book = book, Quantity = newCartItem.Quantity });
            await _context.SaveChangesAsync();
            return new NewCartData { IsNew = true, Index = -1, NewUserData = _mapper.Map<GetUserDTO>(user) };
        }

        public async Task<GetUserDTO> ChangeItemQuantityAsync(string userId, int newQuantity, int index)
        {
            var user = await _context.Users.Include(u => u.Cart).ThenInclude(c => c.Book).Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user.Cart.Count == 0 || index >= user.Cart.Count)
            {
                return null;
            }

            user.Cart[index].Quantity = newQuantity;
            await _context.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<GetUserDTO> RemoveFromCartAsync(string userId, int index)
        {
            var user = await _context.Users.Include(u => u.Cart).ThenInclude(c => c.Book).Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user.Cart.Count == 0 || index >= user.Cart.Count)
            {
                return null;
            }

            _context.Remove(user.Cart.ElementAt(index));
            user.Cart.RemoveAt(index);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<GetUserDTO> ClearCartAsync(string userId)
        {
            var user = await _context.Users.Include(u => u.Cart).ThenInclude(c => c.Book).Where(u => u.Id == userId).FirstOrDefaultAsync();

            _context.RemoveRange(user.Cart);
            user.Cart.Clear();
            await _context.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<List<BookModel>> GetBooksFromCart(string userId)
        {
            var books = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Book)
                .SelectMany(u => u.Cart)
                .Select(c => c.Book)
                .ToListAsync();
            return books;
        }
    }
}

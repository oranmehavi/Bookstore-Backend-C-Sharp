using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Repositories
{
    public interface ICartRepository
    {
        Task<NewCartData> AddToCartAsync(string userId, NewCartItem newCartItem);
        Task<GetUserDTO> ChangeItemQuantityAsync(string userId, int newQuantity, int index);
        Task<GetUserDTO> RemoveFromCartAsync(string userId, int index);
        Task<GetUserDTO> ClearCartAsync(string userId);
        Task<List<BookModel>> GetBooksFromCart(string userId);
    }
}
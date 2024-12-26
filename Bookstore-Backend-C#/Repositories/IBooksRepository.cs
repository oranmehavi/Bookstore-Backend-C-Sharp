using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Repositories
{
    public interface IBooksRepository
    {
        Task<GetReturnedBooksDTO> GetBooksAsync(string searchValue, int? page);
        Task<BookModel> GetBookByIdAsync(string id);
        Task<BookModel> AddNewBookAsync(NewBookModel newBookModel);
        Task<BookModel> UpdateBookAsync(string id, NewBookModel newBookModel);
        Task<int> DeleteByIdAsync(string id);
    }
}
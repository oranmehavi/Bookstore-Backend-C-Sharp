using AutoMapper;
using Bookstore_Backend_C_.Data;
using Bookstore_Backend_C_.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Backend_C_.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;
        public BooksRepository(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetReturnedBooksDTO> GetBooksAsync(string searchValue, int? page)
        {
            int offset = ((page??1) - 1) * 9;

            var booksQuery = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                booksQuery = booksQuery.Where(b => b.BookName.Contains(searchValue));
            }

            var totalBooksInSearch = await booksQuery.CountAsync();
            var books = await booksQuery
                .Skip(page == null && string.IsNullOrWhiteSpace(searchValue) ? 0 : offset)
                .Take(9 /*page == null && string.IsNullOrWhiteSpace(searchValue) ? 0 : 9*/)
                .ToListAsync();

            return new GetReturnedBooksDTO { Books = books, Length = totalBooksInSearch};
        }

        public async Task<BookModel> GetBookByIdAsync(string id)
        {
            var book = await _context.Books.FindAsync(new Guid(id));
            return book;
        }

        public async Task<BookModel> AddNewBookAsync(NewBookModel newBookModel)
        {
            var existingBook = await _context.Books.Where(b => b.BookName == newBookModel.BookName).FirstOrDefaultAsync();
            if (existingBook != null)
            {
                return null;
            }
            BookModel bookModel = _mapper.Map<BookModel>(newBookModel);
            _context.Add(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<BookModel> UpdateBookAsync(string id, NewBookModel newBookModel)
        {
            var book = await _context.Books.FindAsync(new Guid(id));
            if (book == null)
            {
                return null;
            }
            book.BookName = newBookModel.BookName;
            book.Author = newBookModel.Author;
            book.Summary = newBookModel.Summary;
            book.Price = newBookModel.Price;
            book.Discount = newBookModel.Discount;
            book.Image = newBookModel.Image;
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<int> DeleteByIdAsync(string id)
        {
            var book = await _context.Books.FindAsync(new Guid(id));
            if (book != null)
            {
                _context.Books.Remove(book);
                return await _context.SaveChangesAsync();
            }
            return -1;
        }
    }
}

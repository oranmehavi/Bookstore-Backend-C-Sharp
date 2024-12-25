using Bookstore_Backend_C_.Models;
using Bookstore_Backend_C_.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Backend_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksRepository.GetAllBooksAsync();
            if (books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById([FromRoute] string bookId)
        {
            var book = await _booksRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] NewBookModel newBookModel)
        {
            var book = await _booksRepository.AddNewBookAsync(newBookModel);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpPatch("{bookId}")]
        public async Task<IActionResult> UpdateBook([FromRoute] string bookId, [FromBody] NewBookModel newBookModel)
        {
            var book = await _booksRepository.UpdateBookAsync(bookId, newBookModel);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] string bookId)
        {
            var result = await _booksRepository.DeleteByIdAsync(bookId);
            if (result == -1)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

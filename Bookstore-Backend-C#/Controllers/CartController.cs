using Bookstore_Backend_C_.Models;
using Bookstore_Backend_C_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookstore_Backend_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddToCart([FromBody] NewCartItem newCartItem)
        {
            var result = await _cartRepository.AddToCartAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), newCartItem);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new { Data = result});
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllBooksFromCart()
        {
            var books = await _cartRepository.GetBooksFromCart(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (books == null)
            {
                return NotFound();
            }
            return Ok(new { Data = new { BooksData =  books } });   
        }

        [HttpPatch("{index}"), Authorize]
        public async Task<IActionResult> ChangeQuantity([FromQuery] int newQuantity, [FromRoute] int index)
        {
            var user = await _cartRepository.ChangeItemQuantityAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), newQuantity, index);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new { Data = new { UpdatedUser = user } });
        }

        [HttpDelete("{index}"), Authorize]
        public async Task<IActionResult> DeleteFromCart([FromRoute] int index)
        {
            var user = await _cartRepository.RemoveFromCartAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), index);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new { Data = new { UpdatedUser = user } });
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> ClearCart()
        {
            var user = await _cartRepository.ClearCartAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new { Data = new { UpdatedUser = user } });
        }
    }
}

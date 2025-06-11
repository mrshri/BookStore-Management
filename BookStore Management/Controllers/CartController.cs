using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpGet]
        public async Task<ActionResult<AddToCartDto>> GetAllCarts()
        {
            var userId = GetUserId();
            var cart = await _cartService.GetAllCartsAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(AddToCartDto dto)
        {
            var userId = GetUserId();
            await _cartService.AddToCartAsync(userId, dto.BookId, dto.Quantity);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateQuantity(UpdateCartItemDto dto)
        {
            var userId = GetUserId();
            await _cartService.UpdateQuantityAsync(userId, dto.CartItemId, dto.Quantity);
            return Ok();
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = GetUserId();
            await _cartService.RemoveFromCartAsync(userId, cartItemId);
            return Ok();
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();
            await _cartService.ClearCartAsync(userId);
            return Ok();
        }
    }
}

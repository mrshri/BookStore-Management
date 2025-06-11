using AutoMapper;
using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.ModelDtos.OrderDto;
using BookStore_Management.Models;
using BookStore_Management.Repositories.Interfaces;
using BookStore_Management.Service.Interfaces;
using System.Linq;

namespace BookStore_Management.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository,IBookRepository bookRepository,IMapper mapper )
        {
            _cartRepo = cartRepository;
            _bookRepo = bookRepository;
            _mapper = mapper;
                
        }
        public async Task AddToCartAsync(string userId, int bookId, int quantity)
        {

            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _cartRepo.AddToCartAsync(cart);
            }

            var existingItem = cart.Items?.FirstOrDefault(ci => ci.BookId == bookId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Items ??= new List<CartItem>();
                cart.Items.Add(new CartItem { BookId = bookId, Quantity = quantity });
            }

            await _cartRepo.SaveAsync();
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            if (cart != null && cart.Items?.Any() == true)
            {
                cart.Items.Clear();
                await _cartRepo.SaveAsync();
            }
        }

        public async Task<List<AddToCartDto>> GetAllCartsAsync(string userId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);

            // If cart is null or has no items, return an empty list
            if (cart == null || cart.Items == null || !cart.Items.Any())
                return new List<AddToCartDto>();

            // Map all cart items to AddToCartDto
            return cart.Items.Select(item => new AddToCartDto
            {
                BookId = item.BookId,
                Quantity = item.Quantity
            }).ToList();
        }

        public async Task RemoveFromCartAsync(string userId, int cartItemId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            if (cart != null && cart.Items?.Any(ci => ci.Id == cartItemId) == true)
            {
                await _cartRepo.DeleteCartItemAsync(cartItemId);
                await _cartRepo.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(string userId, int cartItemId, int quantity)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            var item = cart?.Items?.FirstOrDefault(ci => ci.Id == cartItemId);

            if (item != null)
            {
                item.Quantity = quantity;
                await _cartRepo.SaveAsync();
            }
        }
    }
}

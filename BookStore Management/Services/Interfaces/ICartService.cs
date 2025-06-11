using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.ModelDtos.OrderDto;
using BookStore_Management.Models;

namespace BookStore_Management.Service.Interfaces
{
    public interface ICartService
    {
        Task<List<AddToCartDto>> GetAllCartsAsync(string userId);
        Task AddToCartAsync(string userId, int bookId, int quantity);
        Task RemoveFromCartAsync(string userId, int cartItemId);
        Task UpdateQuantityAsync(string userId, int cartItemId, int quantity);
        Task ClearCartAsync(string userId);
    }
}

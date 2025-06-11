using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.Models;

namespace BookStore_Management.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddToCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task DeleteCartItemAsync(int cartItemId);
        Task SaveAsync();
    }
}

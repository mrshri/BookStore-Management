using BookStore_Management.DATA;
using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.Models;
using BookStore_Management.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Management.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddToCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
        }


        public async Task DeleteCartItemAsync(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
                _context.CartItems.Remove(item);
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                 .Include(c => c.Items)
                 .ThenInclude(ci => ci.Book)
                 .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
        }
    }
}

using BookStore_Management.DATA;
using BookStore_Management.Models;
using BookStore_Management.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Management.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _Context;
        public BookRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync([FromQuery] string? search)
        {
            var books = await _Context.Books.Include(c => c.Category).ToListAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                books = books.Where(b =>
                    b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    b.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return books; 
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _Context.Books.Include(c => c.Category).FirstOrDefaultAsync(i => i.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public async Task AddAsync(Book book)
        {
            await _Context.Books.AddAsync(book);
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _Context.Books.Remove(book);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _Context.Books.Update(book);
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _Context.Books
                        .Include(b => b.Category)
                        .Where(b => b.CategoryId == categoryId)
                        .ToListAsync();
        }
    }
}

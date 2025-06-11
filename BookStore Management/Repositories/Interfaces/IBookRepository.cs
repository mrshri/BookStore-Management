using BookStore_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Management.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync([FromQuery] string? search );
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);

    }
}

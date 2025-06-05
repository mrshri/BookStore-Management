using BookStore_Management.ModelDtos.BookDtos;

namespace BookStore_Management.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto dto);
        Task<bool> UpdateBookAsync(UpdateBookDto dto);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId);

    }
}

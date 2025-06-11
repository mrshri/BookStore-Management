using AutoMapper;
using BookStore_Management.ModelDtos.BookDtos;
using BookStore_Management.Models;
using BookStore_Management.Repositories;
using BookStore_Management.Repositories.Interfaces;
using BookStore_Management.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Management.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepo,IMapper mapper)
        {
            _bookRepo = bookRepo;  
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync([FromQuery] string?search)
        {
          var books = await _bookRepo.GetAllAsync(search);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book == null ? null : _mapper.Map<BookDto>(book);

        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepo.AddAsync(book);
            return _mapper.Map<BookDto>(book);

        }

        public async Task<bool> UpdateBookAsync(UpdateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(dto.Id);
            if (book == null) return false;

            _mapper.Map(dto, book);
            await _bookRepo.UpdateAsync(book);
            return true;

        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return false;

            await _bookRepo.DeleteAsync(book);
            return true;

        }

        public async Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId)
        {
            var books = await _bookRepo.GetBooksByCategoryAsync(categoryId);
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Price = b.Price,
                ImageUrl = b.ImageUrl,
                CategoryName = b.Category?.Name  // Ensure Category is not null
            });
        }
    }
}

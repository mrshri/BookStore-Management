using AutoMapper;
using BookStore_Management.ModelDtos.CategoryDtos;
using BookStore_Management.Models;
using BookStore_Management.Repositories.Interfaces;
using BookStore_Management.Services.Interfaces;

namespace BookStore_Management.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
             _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepo.AddAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return false;

            await _categoryRepo.DeleteAsync(category);
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var category = await _categoryRepo.GetByIdAsync(dto.Id);
            if (category == null) return false;

            _mapper.Map(dto, category);
            await _categoryRepo.UpdateAsync(category);
            return true;
        }
    }
}

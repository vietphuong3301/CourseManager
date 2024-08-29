using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<CategoryDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize);
        Task<CategoryDto> GetSingleAsync(Expression<Func<CategoryDto, bool>> predicate);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<(IEnumerable<CategoryDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var (categories, totalCount) = await _categoryRepository.GetPagedAsync(pageIndex, pageSize);
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return (categoryDtos, totalCount);
        }

        public async Task<CategoryDto> GetSingleAsync(Expression<Func<CategoryDto, bool>> predicate)
        {
            var categoryPredicate = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
            var category = await _categoryRepository.GetSingleAsync(categoryPredicate);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(category);
            return true;
        }
    }
}

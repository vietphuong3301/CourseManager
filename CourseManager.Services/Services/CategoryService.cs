using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManager.Services.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetById(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<bool> UpdateAsync(CategoryDto category);
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

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
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
            // Chuyển đổi predicate từ CategoryDto sang Category
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

using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<CategoryDto> GetSingleAsync(Expression<Func<CategoryDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
            var category = await _categoryRepository.GetSingleAsync(entityPredicate);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
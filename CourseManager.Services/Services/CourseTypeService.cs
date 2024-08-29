using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using CourseManager.Services.Services;
using System.Linq.Expressions;

namespace CourseManager.Services
{
    public class CourseTypeService : BaseService<CourseType, CourseTypeDto>, ICourseTypeService
    {
        public CourseTypeService(ICourseTypeRepository courseTypeRepository, IMapper mapper)
            : base(courseTypeRepository, mapper)
        {
        }

        public override async Task<CourseTypeDto> GetSingleAsync(Expression<Func<CourseTypeDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<CourseType, bool>>>(predicate);
            var courseType = await _repository.GetSingleAsync(entityPredicate);
            return _mapper.Map<CourseTypeDto>(courseType);
        }
    }
}
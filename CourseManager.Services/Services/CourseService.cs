using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using CourseManager.Services.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public class CourseService : BaseService<Course, CourseDto>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
            : base(courseRepository, mapper)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetByCategoryAsync(int categoryId)
        {
            var courses = await _courseRepository.GetByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<IEnumerable<CourseDto>> GetByCourseTypeAsync(int courseTypeId)
        {
            var courses = await _courseRepository.GetByCourseTypeAsync(courseTypeId);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public override async Task<CourseDto> GetSingleAsync(Expression<Func<CourseDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<Course, bool>>>(predicate);
            var course = await _courseRepository.GetSingleAsync(entityPredicate);
            return _mapper.Map<CourseDto>(course);
        }
    }
}
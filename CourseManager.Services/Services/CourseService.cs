using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public interface ICourseService
    {
        Task<CourseDto> GetByIdAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> CreateAsync(CourseDto courseDto);
        Task<bool> UpdateAsync(CourseDto courseDto);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<CourseDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize);
        Task<CourseDto> GetSingleAsync(Expression<Func<CourseDto, bool>> predicate);
        Task<IEnumerable<CourseDto>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<CourseDto>> GetByCourseTypeAsync(int courseTypeId);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddAsync(course);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<(IEnumerable<CourseDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var (courses, totalCount) = await _courseRepository.GetPagedAsync(pageIndex, pageSize);
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return (courseDtos, totalCount);
        }

        public async Task<CourseDto> GetSingleAsync(Expression<Func<CourseDto, bool>> predicate)
        {
            var coursePredicate = _mapper.Map<Expression<Func<Course, bool>>>(predicate);
            var course = await _courseRepository.GetSingleAsync(coursePredicate);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> UpdateAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.UpdateAsync(course);
            return true;
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
    }
}

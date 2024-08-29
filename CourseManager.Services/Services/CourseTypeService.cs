using AutoMapper;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.DTO.DTOs;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public interface ICourseTypeService
    {
        Task<CourseTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<CourseTypeDto>> GetAllAsync();
        Task<CourseTypeDto> CreateAsync(CourseTypeDto courseTypeDto);
        Task<CourseTypeDto> UpdateAsync(CourseTypeDto courseTypeDto);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<CourseTypeDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize);
        Task<CourseTypeDto> GetSingleAsync(Expression<Func<CourseTypeDto, bool>> predicate);
    }

    public class CourseTypeService : ICourseTypeService
    {
        private readonly ICourseTypeRepository _courseTypeRepository;
        private readonly IMapper _mapper;

        public CourseTypeService(ICourseTypeRepository courseTypeRepository, IMapper mapper)
        {
            _courseTypeRepository = courseTypeRepository;
            _mapper = mapper;
        }

        public async Task<CourseTypeDto> CreateAsync(CourseTypeDto courseTypeDto)
        {
            var courseType = _mapper.Map<CourseType>(courseTypeDto);
            await _courseTypeRepository.AddAsync(courseType);
            return _mapper.Map<CourseTypeDto>(courseType);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _courseTypeRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CourseTypeDto>> GetAllAsync()
        {
            var courseTypes = await _courseTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseTypeDto>>(courseTypes);
        }

        public async Task<CourseTypeDto> GetByIdAsync(int id)
        {
            var courseType = await _courseTypeRepository.GetByIdAsync(id);
            return _mapper.Map<CourseTypeDto>(courseType);
        }

        public async Task<(IEnumerable<CourseTypeDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var (courseTypes, totalCount) = await _courseTypeRepository.GetPagedAsync(pageIndex, pageSize);
            var courseTypeDtos = _mapper.Map<IEnumerable<CourseTypeDto>>(courseTypes);
            return (courseTypeDtos, totalCount);
        }

        public async Task<CourseTypeDto> GetSingleAsync(Expression<Func<CourseTypeDto, bool>> predicate)
        {
            var courseTypePredicate = _mapper.Map<Expression<Func<CourseType, bool>>>(predicate);
            var courseType = await _courseTypeRepository.GetSingleAsync(courseTypePredicate);
            return _mapper.Map<CourseTypeDto>(courseType);
        }

        public async Task<CourseTypeDto> UpdateAsync(CourseTypeDto courseTypeDto)
        {
            var courseType = _mapper.Map<CourseType>(courseTypeDto);
            await _courseTypeRepository.UpdateAsync(courseType);
            return _mapper.Map<CourseTypeDto>(courseType);
        }
    }
}

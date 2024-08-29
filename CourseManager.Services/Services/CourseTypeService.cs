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
    public interface ICourseTypeService
    {
        Task<CourseTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<CourseTypeDto>> GetAllAsync();
        Task<CourseTypeDto> CreateAsync(CourseTypeDto courseType);
        Task<CourseTypeDto> UpdateAsync(CourseTypeDto courseType);
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

        public async Task<CourseTypeDto> CreateAsync(CourseTypeDto courseType)
        {
            var entity = _mapper.Map<CourseType>(courseType);
            await _courseTypeRepository.AddAsync(entity);
            return _mapper.Map<CourseTypeDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _courseTypeRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CourseTypeDto>> GetAllAsync()
        {
            var entities = await _courseTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseTypeDto>>(entities);
        }

        public async Task<CourseTypeDto> GetByIdAsync(int id)
        {
            var entity = await _courseTypeRepository.GetByIdAsync(id);
            return _mapper.Map<CourseTypeDto>(entity);
        }

        public async Task<(IEnumerable<CourseTypeDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var (entities, totalCount) = await _courseTypeRepository.GetPagedAsync(pageIndex, pageSize);
            return (_mapper.Map<IEnumerable<CourseTypeDto>>(entities), totalCount);
        }

        public async Task<CourseTypeDto> GetSingleAsync(Expression<Func<CourseTypeDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<CourseType, bool>>>(predicate);
            var entity = await _courseTypeRepository.GetSingleAsync(entityPredicate);
            return _mapper.Map<CourseTypeDto>(entity);
        }

        public async Task<CourseTypeDto> UpdateAsync(CourseTypeDto courseType)
        {
            var entity = _mapper.Map<CourseType>(courseType);
            await _courseTypeRepository.UpdateAsync(entity);
            return _mapper.Map<CourseTypeDto>(entity);
        }
    }
}

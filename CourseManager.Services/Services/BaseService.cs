using AutoMapper;
using CourseManager.Domain.Interfaces;
using CourseManager.Services.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Services.Services
{
    public abstract class BaseService<TEntity, TDto> : IBaseService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        private IUserRepository userRepository;
        private IMapper mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected BaseService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<bool> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        public virtual async Task<(IEnumerable<TDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize)
        {
            var (entities, totalCount) = await _repository.GetPagedAsync(pageIndex, pageSize);
            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);
            return (dtos, totalCount);
        }

        public virtual async Task<TDto> GetSingleAsync(Expression<Func<TDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entity = await _repository.GetSingleAsync(entityPredicate);
            return _mapper.Map<TDto>(entity);
        }
    }
}
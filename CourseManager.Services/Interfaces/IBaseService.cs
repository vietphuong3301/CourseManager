using System.Linq.Expressions;

namespace CourseManager.Services.Interfaces
{
    public interface IBaseService<TDto> where TDto : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<TDto> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize);
        Task<TDto> GetSingleAsync(Expression<Func<TDto, bool>> predicate);
    }
}
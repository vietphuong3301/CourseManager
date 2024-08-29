using CourseManager.DTO.DTOs;

namespace CourseManager.Services.Interfaces
{
    public interface ICourseService : IBaseService<CourseDto>
    {
        Task<IEnumerable<CourseDto>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<CourseDto>> GetByCourseTypeAsync(int courseTypeId);
    }
}
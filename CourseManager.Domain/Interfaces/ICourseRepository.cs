using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> GetByCategoryAsync(int categoryId);

        Task<IEnumerable<Course>> GetByCourseTypeAsync(int courseTypeId);
    }
}
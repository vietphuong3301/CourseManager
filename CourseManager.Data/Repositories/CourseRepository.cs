using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Courses
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetByCourseTypeAsync(int courseTypeId)
        {
            return await _context.Courses
                .Where(c => c.CourseTypeId == courseTypeId)
                .ToListAsync();
        }
    }
}
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Data.Repositories
{
    public class CourseTypeRepository : BaseRepository<CourseType>, ICourseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
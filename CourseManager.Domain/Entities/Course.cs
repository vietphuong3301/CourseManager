using CourseManager.Domain.Entities.CourseManager.Domain.Entities;

namespace CourseManager.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int CategoryId { get; set; }
        public int CourseTypeId { get; set; }
        public int InstructorId { get; set; }

        // Navigation properties
        public Category Category { get; set; }

        public CourseType CourseType { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
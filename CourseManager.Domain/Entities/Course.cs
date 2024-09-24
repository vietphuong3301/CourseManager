using CourseManager.Domain.Entities.CourseManager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class Course :  BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        [Required]
        public string Title { get; set; }
        [MaxLength(256)]
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
using CourseManager.Domain.Entities.CourseManager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(256)]
        [Required]
        public string Email { get; set; }
        [MaxLength(256)]
        [Required]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
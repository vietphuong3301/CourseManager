using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class Instructor : BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
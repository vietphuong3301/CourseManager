using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [MaxLength(256)]
        [Required]
        public string Email { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
        [MaxLength(256)]
        [Required]
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin", "Instructor", "Student"
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string RoleName { get; set; }

        // Navigation properties
        public ICollection<Instructor> Instructors { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
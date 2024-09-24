using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
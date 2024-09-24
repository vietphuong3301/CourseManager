using System.ComponentModel.DataAnnotations;

namespace CourseManager.Domain.Entities
{
    public class CourseType : BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
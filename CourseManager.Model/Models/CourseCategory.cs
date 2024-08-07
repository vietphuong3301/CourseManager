using CourseManager.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    [Table("CourseCategories")]
    public class CourseCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Name { get; set; }

        [Required]
        public int Alias { get; set; }

        public int Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
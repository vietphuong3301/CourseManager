using CourseManager.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CourseManager.Model.Models
{
    [Table("Courses")]
    public class Course : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public int CategoryID { get; set; }
        public string Image { get; set; }
        public XElement MoreImages { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { set; get; }

        [ForeignKey("CategoryID")]
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual IEnumerable<CourseTag> CourseTags { set; get; }
    }
}
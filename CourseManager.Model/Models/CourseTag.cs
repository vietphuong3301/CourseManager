using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Model.Models
{
    [Table("CourseTags")]
    public class CourseTag
    {
        [Key]
        public int CourseID { set; get; }

        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("CourseID")]
        public virtual Course Course { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}

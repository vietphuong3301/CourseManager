using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    [Table("EnrollDetails")]
    public class EnrollDetail
    {
        [Key]
        public int EnrollID { set; get; }

        [Key]
        public int CourseID { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("EnrollID")]
        public virtual Enroll Enroll { set; get; }

        [ForeignKey("CourseID")]
        public virtual Course Course { set; get; }
    }
}
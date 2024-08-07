using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    public class ApplicationUserGroup
    {
        [StringLength(128)]
        [Key]
        public string UserId { set; get; }

        [Key]
        public int GroupId { set; get; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { set; get; }

        [ForeignKey("GroupId")]
        public virtual ApplicationGroup ApplicationGroup { set; get; }
    }
}
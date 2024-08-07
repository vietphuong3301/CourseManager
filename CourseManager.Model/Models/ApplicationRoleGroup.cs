using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    [Table("ApplicationRoleGroups")]
    public class ApplicationRoleGroup
    {
        [Key]
        public int GroupId { set; get; }

        [StringLength(128)]
        [Key]
        public string RoleId { set; get; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole ApplicationRole { set; get; }

        [ForeignKey("GroupId")]
        public virtual ApplicationGroup ApplicationGroup { set; get; }
    }
}
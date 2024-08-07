using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Menu> Menus { get; set; }
    }
}
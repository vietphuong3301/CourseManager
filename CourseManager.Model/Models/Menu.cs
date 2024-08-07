using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        public int? DisPlayOrder { get; set; }
        [Required]
       
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }

        public string Target {  get; set; }
        [Required]
        public bool Status {  get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Model.Models
{
    [Table("Errors")]
    public class Erorr
    {
        [Key]
        public int ID { set; get; }

        public string Message { set; get; }

        public string StackTrace { set; get; }

        public DateTime CreatedDate { set; get; }
    }
}
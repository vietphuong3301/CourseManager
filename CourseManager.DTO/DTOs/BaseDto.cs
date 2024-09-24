using System.ComponentModel.DataAnnotations;

namespace CourseManager.DTO.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
namespace CourseManager.DTO.DTOs
{
    public class GradeDto
    {
        public decimal Score { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
    }
}
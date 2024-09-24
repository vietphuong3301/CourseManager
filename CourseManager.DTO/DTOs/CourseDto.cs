namespace CourseManager.DTO.DTOs
{
    public class CourseDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public CategoryDto Category { get; set; }
        public CourseTypeDto CourseType { get; set; }
        public InstructorDto Instructor { get; set; }
    }
}
namespace CourseManager.DTO.DTOs
{
    public class UserCourseDto : BaseDto
    {
        public UserDto User { get; set; }
        public CourseDto Course { get; set; }
    }
}
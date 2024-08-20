namespace CourseManager.Domain.Entities
{
    public class UserCourse
    {
        public int UserCourseId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
namespace CourseManager.Domain.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
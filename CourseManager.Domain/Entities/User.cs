namespace CourseManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin", "Instructor", "Student"
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
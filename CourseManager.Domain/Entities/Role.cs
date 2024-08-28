namespace CourseManager.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation properties
        public ICollection<Instructor> Instructors { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
namespace CourseManager.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
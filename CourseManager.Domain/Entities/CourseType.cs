namespace CourseManager.Domain.Entities
{
    public class CourseType
    {
        public int CourseTypeId { get; set; }
        public int Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
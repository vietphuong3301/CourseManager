namespace CourseManager.Domain.Entities
{
    namespace CourseManager.Domain.Entities
    {
        public class Grade : BaseEntity
        {
            public int StudentId { get; set; }
            public Student Student { get; set; }
            public int CourseId { get; set; }
            public Course Course { get; set; }
            public decimal Score { get; set; } // Điểm số
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int CategoryId { get; set; }
        public int CourseTypeId { get; set; }
        public int InstructorId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public CourseType CourseType { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Domain.Entities
{
    public class CourseType
    {
        public int CourseTypeId { get; set; }
        public int Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbFirstDemo.DataModel
{
    public partial class Course
    {
        public Course()
        {
            CourseStudents = new HashSet<CourseStudent>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}

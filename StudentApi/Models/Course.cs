using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseResource> CourseResources { get; set; }
    }
}
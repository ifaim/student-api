using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class CourseResource : BaseEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
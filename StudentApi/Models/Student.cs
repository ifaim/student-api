using System;
using System.Collections.Generic;
using StudentApi.Core;

namespace StudentApi.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public string Username { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
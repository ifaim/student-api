using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;


namespace StudentApi.Models
{
    public class StudentApiDbContext : DbContext
    {

        static StudentApiDbContext()
        {
            //Database.SetInitializer<StudentApiDbContext>(new CreateDatabaseIfNotExists<StudentApiDbContext>());
            //Database.SetInitializer<StudentApiDbContext>(new DropCreateDatabaseIfModelChanges<StudentApiDbContext>());
            Database.SetInitializer<StudentApiDbContext>(new StudentDbInitialize());
        }

        public static StudentApiDbContext Create()
        {
            return new StudentApiDbContext();
        }

        public StudentApiDbContext() : base("name=StudentApiContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseResource> CourseResources { get; set; }
    }

    public class StudentDbInitialize : DropCreateDatabaseIfModelChanges<StudentApiDbContext>
    {
        protected override void Seed(StudentApiDbContext context)
        {
            var students = new List<Student>
            {
                new Student {Email = "faim.sust@gmail.com", Name = "faim" },
                new Student {Email = "faim.sust@gmail.com", Name = "2" },
                new Student {Email = "faim.sust@gmail.com", Name = "3" }
            };

            students.ForEach((student) => context.Students.AddOrUpdate(student));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { Credits = 3, Title = "Test1"},
                new Course { Credits = 3, Title = "Test2" },
                new Course { Credits = 3, Title = "Test3" }
            };

            courses.ForEach(s => context.Courses.AddOrUpdate(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = students.Single((s) => s.Name == "faim").Id,
                    CourseId = courses.Single((c) => c.Title == "Test1").Id,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    StudentId = students.Single((s) => s.Name == "faim").Id,
                    CourseId = courses.Single((c) => c.Title == "Test2").Id,
                }
            };
            enrollments.ForEach((e) => context.Enrollments.Add(e));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
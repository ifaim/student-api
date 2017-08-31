using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentApi.Core;
using StudentApi.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace StudentApi.Models.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetCourses(int studentId);
    }

    public class StudentRepository : IStudentRepository
    {

        StudentApiDbContext dbContext;

        public StudentRepository()
        {
            this.dbContext = new StudentApiDbContext();
        }

        public Student Save(Student student)
        {
            this.dbContext.Students.Add(student);
            this.dbContext.SaveChanges();

            return student;
        }

        public IEnumerable<Student> Get()
        {
            return this.dbContext.Students
                .Include("Enrollments.Course")
                .ToList();
        }
        
        public Student FindById(int id)
        {
            var d = this.dbContext.Students
                .Where((s) => s.Id == id)
                .Include(i => i.Enrollments)
                .FirstOrDefault();
            return d;
        }

        public Student Update(int id, Student student)
        {
            var existStudent = this.dbContext.Students
                .Where(s => s.Id == id)
                .SingleOrDefault();

            if (existStudent == null) throw new Exception("Invalid Id: " + id);

            
            this.dbContext.Entry(student).State = EntityState.Modified;
            this.dbContext.SaveChanges();
            return student;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public Student GetCourses(int studentId)
        {
            return this.dbContext.Students
                .Where((s) => s.Id == studentId)
                //.Include(i => i.Enrollments.Select(e => e.Course.CourseResources))
                .Include("Enrollments.Course.CourseResources")
                .Select(s => s)
                .FirstOrDefault();
        }
    }
}
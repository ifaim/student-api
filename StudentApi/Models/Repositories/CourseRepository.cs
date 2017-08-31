using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentApi.Core;
using StudentApi.Models;

namespace StudentApi.Models.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepository : ICourseRepository
    {
        StudentApiDbContext dbContext;

        public CourseRepository()
        {
            this.dbContext = new StudentApiDbContext();
        }

        public Course Save(Course item)
        {
            this.dbContext.Courses.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public IEnumerable<Course> Get()
        {
            var items = this.dbContext.Courses.Include("CourseResources")
                .ToList();
            return items;
        }

        public Course FindById(int id)
        {
            var item = this.dbContext.Courses
                .Include("CourseResources")
                .Where(c => c.Id == id).SingleOrDefault();
            return item;

        }

        public Course Update(int id, Course student)
        {
            return null;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
using StudentApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models.Repositories
{
    public interface ICourseResourceRepository : IRepository<CourseResource>
    {
        IEnumerable<CourseResource> GetByCourse(int id);
    }

    public class CourseResourceRepository : ICourseResourceRepository
    {
        StudentApiDbContext dbContext;

        public CourseResourceRepository()
        {
            this.dbContext = new StudentApiDbContext();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseResource FindById(int id)
        {
            return this.dbContext.CourseResources.Where(c => c.Id == id).SingleOrDefault();
        }

        public IEnumerable<CourseResource> Get()
        {
            return this.dbContext.CourseResources.ToList();
        }

        public IEnumerable<CourseResource> GetByCourse(int id)
        {
            return this.dbContext.CourseResources
                .Include("Course")
                .Where(c => c.CourseId == id);
                
        }

        public CourseResource Save(CourseResource item)
        {
            this.dbContext.CourseResources.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public CourseResource Update(int id, CourseResource item)
        {
            throw new NotImplementedException();
        }
    }
}
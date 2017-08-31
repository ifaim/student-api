using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using StudentApi.Core;
using StudentApi.Models;
using System.Threading.Tasks;

namespace StudentApi.Models.Repositories
{
    public interface IEnrollerRepository : IRepository<Enrollment>
    {

    }

    public class EnrollerReporitory : IEnrollerRepository
    {
        StudentApiDbContext dbContext;

        public EnrollerReporitory()
        {
            this.dbContext = new StudentApiDbContext();
        }

        public Enrollment Save(Enrollment item)
        {
            this.dbContext.Enrollments.Add(item);
            this.dbContext.SaveChanges();

            return item;
        }

        public IEnumerable<Enrollment> Get()
        {
            var items = dbContext.Enrollments;
                

            //var items = (from e in dbContext.Enrollments select e).ToList();
            return items
                .ToList();
        }

        public Enrollment FindById(int id)
        {
            var item = this.dbContext
                .Enrollments
                .Where((e) => e.Id == id)
                .Single();

            return item;
        }

        public Enrollment Update(int id, Enrollment student)
        {
            return null;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
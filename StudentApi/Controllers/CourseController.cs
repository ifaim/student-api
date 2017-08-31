using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using StudentApi.Models;
using StudentApi.Models.Repositories;
using System.Web.Http.Description;

namespace StudentApi.Controllers
{
    [RoutePrefix("api/v1/courses")]
    public class CourseController : SApiController<Course>
    {
        private ICourseRepository courseRepo;

        public CourseController()
        {
            this.courseRepo = new CourseRepository();
        }

        [HttpPost]
        [Route()]
        [ResponseType(typeof(Course))]
        public IHttpActionResult Save([FromBody] Course course)
        {
            var item = this.courseRepo.Save(course);
            return Ok(item);
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(IEnumerable<Course>))]
        public IHttpActionResult Get()
        {
            var items = this.courseRepo.Get();
            return Ok(items);
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(Course))]
        public IHttpActionResult Get(int id)
        {
            var item = this.courseRepo.FindById(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}

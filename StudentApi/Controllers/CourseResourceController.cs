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
    [RoutePrefix("api/v1/courses/resources")]
    public class CourseResourceController : SApiController<CourseResource>
    {
        private ICourseResourceRepository repo;

        public CourseResourceController()
        {
            this.repo = new CourseResourceRepository();
        }

        [HttpPost]
        [Route()]
        public IHttpActionResult Save([FromBody] CourseResource item)
        {
            if (item.CourseId > 0 && item.Link == null)
            {
                return BadRequest();
            }

            var data = this.repo.Save(item);
            return Ok(item);
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult Get()
        {
            
                var data = this.repo.Get();
                return Ok(data);
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult Get(int courseId)
        {
            var data = this.repo.GetByCourse(courseId);
            return Ok(data);
        }
    }
}

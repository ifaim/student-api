using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using StudentApi.Models;
using StudentApi.Models.Repositories;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [RoutePrefix("api/v1/enrollments")]
    public class EnrollmentController : SApiController<Enrollment>
    {
        private IEnrollerRepository enrollerRepo;

        public EnrollmentController()
        {
            this.enrollerRepo = new EnrollerReporitory();
        }

        [HttpPost]
        [Route()]
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult Save([FromBody] Enrollment enroll)
        {
            var item = this.enrollerRepo.Save(enroll);
            return Ok(item);
        }

        [HttpGet]
        [Route()]
        public IEnumerable<Enrollment> Get()
        {
            var items = this.enrollerRepo.Get();
            return items;
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult Get(int id)
        {
            var item = this.enrollerRepo.FindById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}

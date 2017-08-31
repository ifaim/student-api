using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using StudentApi.Models;
using StudentApi.Models.Repositories;
using System.Web.Http.Description;

namespace StudentApi.Controllers
{
    [RoutePrefix("api/v1/students")]
    public class StudentController : SApiController<Student>
    {
        private StudentRepository studentRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository();
        }

        [HttpPost]
        [Route()]
        [ResponseType(typeof(Student))]
        public IHttpActionResult Save([FromBody] Student student)
        {
            if(student.Email == null)
            {
                return BadRequest();
            }

            var item = this.studentRepository.Save(student);

            return Ok(item);
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult Get()
        {
            var students = this.studentRepository.Get();
            return Ok(students);
        }

        [HttpGet]
        [Route("courses")]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult Get(int studentId)
        {
            var students = this.studentRepository.GetCourses(studentId);
            return Ok(students);
        }

        [HttpPatch]
        [Route("{studentId}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult Update(int studentId, [FromBody] Student student)
        {
            var students = this.studentRepository.Update(studentId, student);
            return Ok(students);
        }
    }
}
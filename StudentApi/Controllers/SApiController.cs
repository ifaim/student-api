using System.Web.Http;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    public class SApiController<T> : ApiController where T : BaseEntity
    {
        public SApiController()
        {
        }
    }
}
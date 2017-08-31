using StudentApi.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace StudentApi.Controllers
{
    [RoutePrefix("api/v1/upload")]
    public class UploadController : ApiController
    {
        public UploadController()
        {

        }
        

        //[HttpPost]
        //[Route()]
        //public HttpResponseMessage upload()
        //{
        //    //if (!Request.Content.IsMimeMultipartContent())
        //    //{
        //    //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Request!");
        //    //    throw new HttpResponseException(response);
        //    //}

        //    var task = this.Request.Content.ReadAsStreamAsync();
        //    task.Wait();

        //    Stream requestStream = task.Result;
        //    string uploadPath = "C:\\Temp";

        //    try
        //    {
        //        Stream fileStream = File.Create(HttpContext.Current.Server.MapPath("~/App_Data/" + Guid.NewGuid().ToString() + ".jpg"));
        //        requestStream.CopyTo(fileStream);
        //        fileStream.Close();
        //        requestStream.Close();
        //    }
        //    catch (IOException)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.InternalServerError);
        //    }

        //    //StreamProvider streamProvider = new StreamProvider(uploadPath);

        //    //await Request.Content.ReadAsMultipartAsync(streamProvider);

        //    List<string> messages = new List<string>();
        //    //foreach (var file in streamProvider.FileData)
        //    //{
        //    //    FileInfo fi = new FileInfo(file.LocalFileName);
        //    //    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
        //    //}

        //    HttpResponseMessage response = new HttpResponseMessage();
        //    response.StatusCode = HttpStatusCode.Created;
        //    return response;
        //}

        [HttpPost]
        [Route()]
        public async Task<Object> Post()
        {
            var request = HttpContext.Current.Request;
            String RelativePath = null;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/files");
            //var provider = new MultipartFormDataStreamProvider(root);
            StreamProvider provider = new StreamProvider(root);

            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }
                    var fileName = "";
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        fileName = file.LocalFileName;
                    }
                    var appPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                    RelativePath = request.Url.Scheme + "://" + request.Url.Authority + request.ApplicationPath.TrimEnd('/') + "/" + fileName.Substring(appPath.Length).Replace('\\', '/');
                    return Request.CreateResponse(HttpStatusCode.OK);
                });
            await task;

            return Ok(new {
                Url = RelativePath
            });
        }
    }
}

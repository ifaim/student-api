using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

using StudentApi.Models;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(StudentApi.Startup))]

namespace StudentApi
{
    public class Startup
    {
        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigAuth(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void ConfigAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.CreatePerOwinContext(StudentApiDbContext.Create);

            PublicClientId = "self";
            
        }
    }
}

using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Bigrivers.Server.Data;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Bigrivers.Server.Webservice.App_Start.Startup))]

namespace Bigrivers.Server.Webservice.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            Database.SetInitializer<BigriversDb>(null);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}

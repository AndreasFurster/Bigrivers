using System.Data.Entity;
using System.Web.Http;
using Bigrivers.Server.Data;
using Bigrivers.Server.Webservice;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Bigrivers.Server.Webservice
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
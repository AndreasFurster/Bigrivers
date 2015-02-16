using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Security.Policy;
using System.Web.Http;
using Bigrivers.Server.Data;
using Bigrivers.Server.Webservice;
using Bigrivers.Server.Webservice.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
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


            ConfigureAuth(app);

            ConfigureWebApi(config);

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(config);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/Account/Authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                Provider = new OAuthAuthorizationServerProvider(),
#if DEBUG
                AllowInsecureHttp = true
#endif
            };


            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext(IdentityDb.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Plugin the OAuth bearer tokens generation and Consumption will be here
            app.UseOAuthBearerTokens(oAuthOptions);
            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
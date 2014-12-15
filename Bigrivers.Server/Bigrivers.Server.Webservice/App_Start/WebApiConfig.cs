using System.Web.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Bigrivers.Server.Model;
using Microsoft.OData.Edm;

namespace Bigrivers.Server.Webservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Api",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //// Remove XML formatter to prevent XML output
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //// Adding JSON formatter
            //JsonMediaTypeFormatter jmf = config.Formatters.JsonFormatter;
            //jmf.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //config.Formatters.Add(jmf);

            /* ====== OData config ====== */

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: GetModel()
            );
        }

        public static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Artist>("Artist");
            builder.EntitySet<Event>("Event");
            builder.EntitySet<Genre>("Genre");
            builder.EntitySet<Location>("Location");
            builder.EntitySet<NewsItem>("NewsItem");
            builder.EntitySet<Page>("Page");
            builder.EntitySet<Performance>("Performance");
            builder.EntitySet<Sponsor>("Sponsor");

            return builder.GetEdmModel();
        }
    }
}

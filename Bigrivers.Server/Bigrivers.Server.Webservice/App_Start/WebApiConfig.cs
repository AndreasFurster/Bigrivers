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
            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.MapODataServiceRoute(
                routeName: "OData",
                routePrefix: "odata",
                model: GetModel()
            );

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remove XML formatter to prevent XML output
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Adding JSON formatter
            JsonMediaTypeFormatter jmf = config.Formatters.JsonFormatter;
            jmf.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.Formatters.Add(jmf);
        }

        public static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Artist>("Artists");
            builder.EntitySet<Event>("Events");
            builder.EntitySet<Genre>("Genres");
            builder.EntitySet<Location>("Locations");
            builder.EntitySet<NewsItem>("NewsItems");
            builder.EntitySet<Page>("Pages");
            builder.EntitySet<Sponsor>("Sponsors");


            return builder.GetEdmModel();
        }
    }
}

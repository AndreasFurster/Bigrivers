using System.Web.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace Bigrivers.Server.Webservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Mapping OData routes
            config.MapODataServiceRoute(
                routeName: "OData",
                routePrefix: "odata",
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
            //builder.EntitySet<NewsItem>("NewsItem");
            //builder.EntitySet<Page>("Page");
            //builder.EntitySet<Sponsor>("Sponsor");

            return builder.GetEdmModel();
        }
    }
}

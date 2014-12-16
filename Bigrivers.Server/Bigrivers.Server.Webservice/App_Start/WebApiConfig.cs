using System.Web.Http;
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
            config.MapHttpAttributeRoutes();

            // Mapping OData routes
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: GetModel()
            );
        }

        public static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Artist>("Artists");
            builder.EntitySet<Event>("Events");
            builder.EntitySet<Genre>("Genres");
            builder.EntitySet<Location>("Locations");
            builder.EntitySet<Performance>("Performances");
            builder.EntitySet<Sponsor>("Sponsors");

            return builder.GetEdmModel();
        }
    }
}

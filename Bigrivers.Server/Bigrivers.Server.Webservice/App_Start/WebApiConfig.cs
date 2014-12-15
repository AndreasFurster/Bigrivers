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

            //// Remove XML formatter to prevent XML output
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //// Adding JSON formatter
            //JsonMediaTypeFormatter jmf = config.Formatters.JsonFormatter;
            //jmf.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //config.Formatters.Add(jmf);
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

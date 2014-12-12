﻿using System.Web.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace Bigrivers.Server.Webservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

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
    }
}
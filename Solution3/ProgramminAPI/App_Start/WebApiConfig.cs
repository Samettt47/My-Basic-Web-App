using ProgramminAPI.Attributes;
using ProgramminAPI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProgramminAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetleri

            // Web API yolları
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttributes());
            config.MessageHandlers.Add(new APIKeyHandler());
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );
        }
    }
}

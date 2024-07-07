 using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity.Lifetime;
using Unity; 
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Reflection;
using Microsoft.SqlServer.Server;
using System.Web.Mvc;
using SimpleInjector.Integration.Web;
 

namespace WebApCalc
{
    public static class WebApiConfig
    {
        public static void Register(System.Web.Http.HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            var cors = new EnableCorsAttribute("http://localhost:9646", "*", "*");
            config.EnableCors(cors);
        

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        
    }
}

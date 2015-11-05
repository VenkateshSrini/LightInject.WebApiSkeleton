
using System.Net.Http.Formatting;
using System.Web.Http;
using LightInject;

namespace WebApiSkeleton.WebApi
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureHttpRoutes(this HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
               name: "API Default",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional });
        }

        public static IServiceContainer EnableLightInject(this HttpConfiguration configuration)
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.EnableWebApi(configuration);
            return container;
        }

        public static void UseJson(this HttpConfiguration configuration)
        {
            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using LightInject;
using Owin;
using Swashbuckle.Application;
using WebApiSkeleton.Server;

namespace WebApiSkeleton.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.ConfigureHttpRoutes();
            config.MapHttpAttributeRoutes();
            config.EnableLightInject();
            config.UseJson();

            Configure(config.EnableLightInject());
            ConfigureSwagger(config);

            app.UseWebApi(config);
        }
    
        /// <summary>
        /// Configures the <see cref="IServiceContainer"/>. 
        /// </summary>
        /// <param name="serviceContainer">The <see cref="IServiceContainer"/> to be configured.</param>
        public virtual void Configure(IServiceContainer serviceContainer)
        {
            serviceContainer.RegisterFrom<CompositionRoot>();
        }

        private static void ConfigureSwagger(HttpConfiguration config)
        {
            config.EnableSwagger(
                c =>
                {
                    c.SingleApiVersion("v1", "WebApiSkeleton")
                        .Description("WebApi Skeleton");
                    c.IncludeXmlComments(GetXmlCommentsPathForControllers());
                })
                .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPathForControllers()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            return commentsFile;
        }
    }
}

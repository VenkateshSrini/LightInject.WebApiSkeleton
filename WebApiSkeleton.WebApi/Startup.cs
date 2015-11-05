using System.Web.Http;
using LightInject;
using Owin;
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
    }
}

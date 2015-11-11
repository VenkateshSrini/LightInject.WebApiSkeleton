using Topshelf;

namespace WebApiSkeleton.SelfHost
{
    class Program
    {
        private static int Main()
        {
            return (int)HostFactory.Run(
                 host =>
                 {
                     host.Service<WebApplication>(
                         service =>
                         {
                             service.ConstructUsing(() => new WebApplication());
                             service.WhenStarted(s => s.Start());
                             service.WhenStopped(s => s.Stop());                             
                         });
                     host.RunAsLocalSystem();
                     host.SetServiceName("WebApiSkeleton");
                     host.SetDisplayName("WebApiSkeleton");
                     host.SetDescription("WebApiSkeleton Web Server");                     
                 });
        }
    }
}

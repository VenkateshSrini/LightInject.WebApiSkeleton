using System;
using System.Configuration;using Microsoft.Owin.Hosting;
using WebApiSkeleton.WebApi;


namespace WebApiSkeleton.SelfHost
{
    public class WebApplication
    {
        private IDisposable m_application;

        public void Start()
        {
            m_application = WebApp.Start<Startup>(ConfigurationManager.AppSettings.Get("SelfHostUrl"));
        }

        public void Stop()
        {
            m_application.Dispose();
        }
    }
}

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Owin;
using Tabro.WebApp.App_Start;

namespace Tabro.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            UnityWebActivator.Start();

            EventFlowConfig.Configure(container);
        }
    }
}
using Common;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace engine_insta_back
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var localPath = AppDomain.CurrentDomain.BaseDirectory;
            AppSettings.SetLocalPath(localPath);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

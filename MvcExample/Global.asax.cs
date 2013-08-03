using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using MvcExample.Infrastructure;
using Microsoft.AspNet.SignalR;

namespace MvcExample
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalLoggingFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogExceptionFilterAttribute());
            filters.Add(new LogActionFilterAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Log", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("~/log4net.config")));

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalLoggingFilters(GlobalFilters.Filters);

            RouteTable.Routes.MapHubs();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
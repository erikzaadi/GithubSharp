using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;
using Ninject.Web.Mvc;
using Ninject;

namespace GithubSharp.MvcSample.MvcApplication
{
    public class ServerApp : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("robots.txt");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(System.Reflection.Assembly.GetExecutingAssembly());

        }

        protected override Ninject.IKernel CreateKernel()
        {
            return new StandardKernel(new ServiceModule());
        }
    }
}

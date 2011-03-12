using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Website
{
    public class MvcApplication : HttpApplication
    {
        public override void Init()
        {
            base.Init();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Note", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
    }
}
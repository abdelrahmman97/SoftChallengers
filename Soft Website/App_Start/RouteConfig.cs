using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_1",
                url: "{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default_2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Team Index View
            routes.MapRoute(
                name: "TeamIndex",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Teams", action = "Index", id = UrlParameter.Optional }
            );

            // Works Index View
            routes.MapRoute(
                name: "WorksIndex",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Works", action = "Index", id = UrlParameter.Optional }
            );

            // Account Index View
            routes.MapRoute(
                name: "AccountIndex",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AccountIndex_1",
                url: "{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AccountLogOff",
                url: "{id}",
                defaults: new { controller = "Account", action = "LogOff", id = UrlParameter.Optional }
            );

            // Categories Index View
            routes.MapRoute(
                name: "CategoriesIndex",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Categories", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoriesIndex_1",
                url: "{id}",
                defaults: new { controller = "Categories", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}

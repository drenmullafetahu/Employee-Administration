using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rehber
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "", new { controller = "Login", action = "login" });
            routes.MapRoute("Afterlogin", "afterlogin", new { controller = "Login", action = "Afterlogin" });
            routes.MapRoute("Admin", "Admin", new { controller = "Admin", action = "index", id = UrlParameter.Optional });
            routes.MapRoute("Edit", "Edit", new { controller = "Admin", action = "Edit", id = UrlParameter.Optional });

            
          
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Widget.WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "", 
                "", 
                new { Controller = "Widget", Action = "Index" }
            );

            routes.MapRoute(
                "",
                "calculate",
                new { Controller = "Widget", Action = "Calculate" }
            );
        }
    }
}

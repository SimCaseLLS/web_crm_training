﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrainingCentersCRM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Default",
                url: "{tc}/{controller}/{action}/{id}",
                defaults: new { tc = "empty", controller = "Home", action = "Index", id = UrlParameter.Optional }
                //url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}

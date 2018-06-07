// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 04-07-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 05-15-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpeedoModels
{
    /// <summary>
    /// Class RouteConfig.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "ViewProducts", id = UrlParameter.Optional }
            );
        }
    }
}

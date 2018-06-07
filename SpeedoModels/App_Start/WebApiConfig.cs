// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 04-09-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 04-10-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SpeedoModels
{
    /// <summary>
    /// Class WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

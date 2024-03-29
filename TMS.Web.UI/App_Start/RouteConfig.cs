﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMS.Web.UI
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );

      //routes.MapRoute
      //  (
      //    "DetailsAction",
      //    "{controller}/{id}",
      //    new { action = "Details" },
      //    new {httpMethod = new HttpMethodConstraint("GET")}
      //  );

      //routes.MapRoute
      //  (
      //    "DeleteAction",
      //    "{controller}/{id}",
      //    new { action = "Delete" },
      //    new { httpMethod = new HttpMethodConstraint("DELETE") }
      //  );

    }
  }
}
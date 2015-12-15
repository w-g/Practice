using Sediment.Web.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Sediment.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Marry", action = "Index", id = UrlParameter.Optional }
            );

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SedimentViewEngine());
        }
    }
}
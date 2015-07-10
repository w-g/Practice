using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PluginController : Controller
    {
        // GET: Plugin
        public ActionResult UserPicker()
        {
            return View();
        }
    }
}
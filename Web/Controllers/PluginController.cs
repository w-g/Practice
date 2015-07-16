using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sediment.Web.Controllers
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
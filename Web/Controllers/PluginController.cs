using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sediment.Web.Controllers
{
    public class PluginController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxAction()
        {
            return Content("This is AjaxAction!");
        }

        [HttpPost]
        public ActionResult Action()
        {
            return Content("This is Action!");
        }
    }
}
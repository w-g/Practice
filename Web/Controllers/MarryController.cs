using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sediment.Web.Controllers
{
    public class MarryController : Controller
    {
        // GET: Marry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yes()
        {
            return View();
        }

        public ActionResult No()
        {
            return RedirectToAction("Fool");
        }

        public ActionResult ConfirmYes()
        {
            return View();
        }

        public ActionResult Fool()
        {
            return View();
        }
    }
}
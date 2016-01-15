using System.Web.Mvc;

namespace Sediment.Web.Controllers
{
    public class UIController : Controller
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
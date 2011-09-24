using System;
using System.Web.Mvc;
using log4net;

namespace MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LogManager.GetLogger("").Info("Example message logged by HomeController.Index()");
            return View();
        }

        public ActionResult Throw()
        {
            throw new Exception("Sample exception thrown by controller.");
        }

        public ActionResult Log()
        {
            return View();
        }
    }
}

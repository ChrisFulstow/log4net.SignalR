using System.Web.Mvc;
using log4net;

namespace Log4NetWebAppender.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logger = LogManager.GetLogger("");
            logger.Info("Homepage loaded");
            return View();
        }

        public ActionResult Log()
        {
            return View();
        }
    }
}

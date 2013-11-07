using log4net;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Throw()
        {
            throw new Exception("Sample exception thrown by controller.");
        }

        public ActionResult Log()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                LogManager.GetLogger("").Info("Example message logged by HomeController.Index()");
                Thread.Sleep(5000);
                LogManager.GetLogger("").Warn("Example message logged by HomeController.Index() on WARN");
                Thread.Sleep(5000);
                LogManager.GetLogger("").Debug("Example message logged by HomeController.Index() on DEBUG");
            }, TaskCreationOptions.LongRunning);

            return View();
        }
    }
}

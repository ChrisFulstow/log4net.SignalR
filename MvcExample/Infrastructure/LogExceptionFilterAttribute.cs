using System.Web.Mvc;
using log4net;

namespace MvcExample.Infrastructure
{
    public class LogExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            LogManager.GetLogger("").Error("Exception", filterContext.Exception);
        }
    }
}
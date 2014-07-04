#region Using directives

using System.Web.Mvc;
using log4net;

#endregion


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
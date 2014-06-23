#region Using directives

using System.Web.Mvc;
using log4net;

#endregion


namespace MvcExample.Infrastructure
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LogManager.GetLogger("").Info("ActionExecuted: " +
                                          context.ActionDescriptor.ControllerDescriptor.ControllerName + "." +
                                          context.ActionDescriptor.ActionName);

            base.OnActionExecuted(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var resultType = context.Result.GetType().Name;
            LogManager.GetLogger("").Info("ResultExecuted: " + context.Controller + " ⇒ " + resultType);

            base.OnResultExecuted(context);
        }
    }
}
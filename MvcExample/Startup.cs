#region Using directives

using log4net;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using MvcExample;
using Owin;

#endregion

[assembly: OwinStartup(typeof(Startup))]
namespace MvcExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogManager.GetLogger("").Info("Logging this so that the log4net framework loads the SignalrAppender class before the SignalrAppendHub runs which expects an instance of the SignalrAppend class.");
            app.MapSignalR(new HubConfiguration {
                EnableDetailedErrors = true,
                EnableJSONP = true,
                EnableJavaScriptProxies = true
            });
        }
    }
}
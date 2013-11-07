using Microsoft.Owin;
using MvcExample;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MvcExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
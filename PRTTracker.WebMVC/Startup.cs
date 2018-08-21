using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRTTracker.WebMVC.Startup))]
namespace PRTTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

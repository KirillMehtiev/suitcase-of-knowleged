using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacebookIntegration.Startup))]
namespace FacebookIntegration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

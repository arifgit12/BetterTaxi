using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BetterTaxi.Web.Startup))]
namespace BetterTaxi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

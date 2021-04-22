using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OwnYourDay.WebMVC.Startup))]
namespace OwnYourDay.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

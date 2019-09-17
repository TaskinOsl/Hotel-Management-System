using Microsoft.Owin;
using Owin;
using Web.HMS;

[assembly: OwinStartup(typeof(Startup))]
namespace Web.HMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

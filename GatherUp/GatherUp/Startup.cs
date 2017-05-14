using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GatherUp.Startup))]
namespace GatherUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GatherUP.Startup))]
namespace GatherUP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

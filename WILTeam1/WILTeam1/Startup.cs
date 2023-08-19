using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WILTeam1.Startup))]
namespace WILTeam1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

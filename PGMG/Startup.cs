using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PGMG.Startup))]
namespace PGMG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

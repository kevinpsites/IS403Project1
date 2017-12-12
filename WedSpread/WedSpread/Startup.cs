using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WedSpread.Startup))]
namespace WedSpread
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

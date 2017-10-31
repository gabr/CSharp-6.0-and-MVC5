using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ANOUC.Startup))]
namespace ANOUC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

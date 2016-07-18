using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS.Client.Startup))]
namespace CMS.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

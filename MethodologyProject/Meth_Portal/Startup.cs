using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Meth_Portal.Startup))]
namespace Meth_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

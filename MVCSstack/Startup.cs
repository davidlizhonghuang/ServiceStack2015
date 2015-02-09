using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSstack.Startup))]
namespace MVCSstack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

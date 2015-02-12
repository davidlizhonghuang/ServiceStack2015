using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceStackMVCClient.Startup))]
namespace ServiceStackMVCClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DRDevSampleAzureNetWebApp.Startup))]
namespace DRDevSampleAzureNetWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

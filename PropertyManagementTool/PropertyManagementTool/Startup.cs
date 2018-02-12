using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyManagementTool.Startup))]
namespace PropertyManagementTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

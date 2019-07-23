using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabortaryManagementSystem.Startup))]
namespace LabortaryManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

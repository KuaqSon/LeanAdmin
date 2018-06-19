using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeanAdmin.Startup))]
namespace LeanAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

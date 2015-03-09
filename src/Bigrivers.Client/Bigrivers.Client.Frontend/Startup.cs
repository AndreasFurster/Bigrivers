using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigRivers.Client.Frontend.Startup))]
namespace BigRivers.Client.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

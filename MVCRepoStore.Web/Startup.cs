using Microsoft.Owin;
using MVCRepoStore.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MVCRepoStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

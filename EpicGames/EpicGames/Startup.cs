using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EpicGames.Startup))]
namespace EpicGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BienvenidosUyInicial.Startup))]
namespace BienvenidosUyInicial
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

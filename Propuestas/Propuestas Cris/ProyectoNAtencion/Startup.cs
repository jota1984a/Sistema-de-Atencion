using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoNAtencion.Startup))]
namespace ProyectoNAtencion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

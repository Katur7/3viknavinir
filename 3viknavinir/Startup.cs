using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3viknavinir.Startup))]
namespace _3viknavinir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

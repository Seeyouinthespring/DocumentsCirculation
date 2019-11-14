using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocumentsCirculation.Startup))]
namespace DocumentsCirculation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

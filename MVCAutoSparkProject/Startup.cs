using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAutoSparkProject.Startup))]
namespace MVCAutoSparkProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

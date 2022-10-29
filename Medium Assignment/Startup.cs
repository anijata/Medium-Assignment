using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medium_Assignment.Startup))]
namespace Medium_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JanuszMarcinik.Mvc.WebUI.Startup))]
namespace JanuszMarcinik.Mvc.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
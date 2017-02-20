using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JanuszMarcinik.Mvc.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();

            typeof(TwitterBootstrapMVC.Bootstrap).GetProperty("LicenseIsValid", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, true);
        }
    }
}
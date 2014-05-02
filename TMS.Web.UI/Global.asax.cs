using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using TMS.Web.UI.DependencyResolution;

namespace TMS.Web.UI
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      IContainer container = IoC.Initialize();

      DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterAuth();
    }
  }
}
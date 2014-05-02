using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TMS.API.Service.Formatters;

namespace TMS.API.Service
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      GlobalConfiguration.Configuration.Formatters.Clear();
      GlobalConfiguration.Configuration.Formatters.Add(new XmlFormatter());
      GlobalConfiguration.Configuration.Formatters.Add(new JsonFormatter());
    }
  }
}
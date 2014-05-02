using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TMS.ServiceAPI;
using TMS.ServiceAPI.Formatters;

namespace TMS.API.Service
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
          WebApiConfig.Register();
          FilterConfig.RegisterGlobalFilters();
          RouteConfig.RegisterRoutes(RouteTable.Routes);
          GlobalConfiguration.Configuration.Formatters.Clear();
          GlobalConfiguration.Configuration.Formatters.Add(new XmlFormatter());
          GlobalConfiguration.Configuration.Formatters.Add(new JsonFormatter());
        }
    }
}

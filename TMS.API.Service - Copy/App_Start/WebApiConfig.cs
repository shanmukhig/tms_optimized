using System.Web.Http;
using HttpMethodConstraint = System.Web.Routing.HttpMethodConstraint;

namespace TMS.ServiceAPI
{
  public static class WebApiConfig
  {
    public static void Register()
    {
      //GetOne
      GlobalConfiguration.Configuration.Routes.MapHttpRoute
        (
          "GetOneAction",
          "api/{controller}/{id}",
          new { action = "GetOne" },
          new { httpMethod = new HttpMethodConstraint("GET") }
        );

      //Get
      GlobalConfiguration.Configuration.Routes.MapHttpRoute
        (
          "GetAction",
          "api/{controller}",
          new { action = "Get" },
          new { httpMethod = new HttpMethodConstraint("GET") }
        );

      //Create
      GlobalConfiguration.Configuration.Routes.MapHttpRoute
        (
          "PostAction",
          "api/{controller}",
          new { action = "Create" },
          new { httpMethod = new HttpMethodConstraint("POST") }
        );

      //Update
      GlobalConfiguration.Configuration.Routes.MapHttpRoute
        (
          "PutAction",
          "api/{controller}",
          new { action = "Update" },
          new { httpMethod = new HttpMethodConstraint("PUT") }
        );

      //Delete
      GlobalConfiguration.Configuration.Routes.MapHttpRoute
        (
          "DeleteAction",
          "api/{controller}/{id}",
          new { action = "Delete" },
          new { httpMethod = new HttpMethodConstraint("DELETE") }
        );

      // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
      // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
      // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
      //config.EnableQuerySupport();

      // To disable tracing in your application, please comment out or remove the following line of code
      // For more information, refer to: http://www.asp.net/web-api
      //GlobalConfiguration.Configuration.EnableSystemDiagnosticsTracing();
    }
  }
}

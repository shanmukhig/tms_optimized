using System.Net.Http;

namespace TMS.API.Service.Controllers
{
  public interface IController<in T> where T : class
  {
    HttpResponseMessage Get(int? count);
    //HttpResponseMessage Get(string searchString);
    HttpResponseMessage Get(string id);
    HttpResponseMessage Create(T resource);
    HttpResponseMessage Update(T resource);
    HttpResponseMessage Delete(string Id);
  }
}
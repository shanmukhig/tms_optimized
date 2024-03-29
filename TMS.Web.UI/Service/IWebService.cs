using System.Collections.Generic;

namespace TMS.Web.UI.Service
{
  public interface IWebService<T> where T : class
  {
    IEnumerable<T> Get(int? count);
    IEnumerable<T> Search(string searchString);
    T Get(string id);
    T Create(T resource);
    T Update(T resource);
    void Delete(string id);
  }
}
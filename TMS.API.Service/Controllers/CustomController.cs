using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS.Business;

namespace TMS.API.Service.Controllers
{
  public abstract class CustomController<T> : ApiController, IController<T> where T : class
  {
    private readonly IDomainService<T> _domainService;

    protected CustomController(IDomainService<T> domainService)
    {
      _domainService = domainService;
    }

    public virtual HttpResponseMessage Get(int? count)
    {
      IQueryable<T> ts = _domainService.Get(count);

      //if (ts == null || !ts.Any())
      //  Error(HttpStatusCode.NoContent, "No {0}s found.");

      return Request.CreateResponse(HttpStatusCode.OK, ts);
    }

    public virtual HttpResponseMessage Get(string searchString)
    {
      if (string.IsNullOrWhiteSpace(searchString))
        return Get((int?)null);
      IQueryable<T> ts = _domainService.Get(searchString);
      //if (ts == null || !ts.Any())
      //  Error(HttpStatusCode.NotFound, "No Course found for the given Id: {0}.", new object[] { searchString });

      return Request.CreateResponse(HttpStatusCode.OK, ts);
    }

    public virtual HttpResponseMessage Create(T resource)
    {
      if (resource == null)
        Error(HttpStatusCode.BadRequest, "Incorrect {0} details.");

      T t = _domainService.Create(resource);

      if(resource == null)
        Error(HttpStatusCode.BadRequest, "Error while creating {0}.");

      return Request.CreateResponse(HttpStatusCode.Created, t);
    }

    [HttpPut]
    public virtual HttpResponseMessage Update(T resource)
    {
      if(resource == null)
        Error(HttpStatusCode.BadRequest, "Incorrect {0} details.");
      return Request.CreateResponse(HttpStatusCode.OK, _domainService.Update(resource));
    }

    public virtual HttpResponseMessage Delete(string id)
    {
      if (_domainService.Get(id) == null)
        Error(HttpStatusCode.NotFound, "No {1} found for the given id: {0}", new object[] { id });

      _domainService.Delete(id);
      return Request.CreateResponse(HttpStatusCode.OK);
    }

    protected void Error(HttpStatusCode statusCode, string errorMessage = null, IList<object> args = null)
    {
      if (args == null)
        args = new object[] {typeof (T).Name};
      else
      {
        args.Add(typeof (T).Name);
      }

      string message = string.IsNullOrWhiteSpace(errorMessage)
        ? string.Empty
        : string.Format(errorMessage, args);

      throw new HttpResponseException(
        new HttpResponseMessage
        {
          StatusCode = statusCode,
          Content = new StringContent(message),
          ReasonPhrase = message
        });
    }
  }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using TMS.Entities;
using TMS.Web.UI.Controllers;

namespace TMS.Web.UI.Service
{
  public class UserExtentions : IuserExtentions
  {
    private readonly IWebService<Lead> _leadWebService;
    private readonly IWebService<Instructor> _instructorWebService;
    private readonly IWebService<InternalUser> _internalUserWebService;
    private readonly IWebService<User> _userWebService;

    public UserExtentions(IWebService<Lead> leadWebService, IWebService<Instructor> instructorWebService,
      IWebService<InternalUser> internalUserWebService, IWebService<User> userWebService)
    {
      _leadWebService = leadWebService;
      _instructorWebService = instructorWebService;
      _internalUserWebService = internalUserWebService;
      _userWebService = userWebService;
    }

    public dynamic GetUserDetails(User user)
    {
      return GetUserDetails(new List<User> {user}).Single();
    }

    public dynamic GetUserDetails(string id)
    {
      return GetUserDetails(new List<string> {id}).SingleOrDefault();
    }

    public IEnumerable<dynamic> GetUserDetails(IEnumerable<string> ids)
    {
      return GetUserDetails(ids.Where(x => !string.IsNullOrWhiteSpace(x)).Select(id => _userWebService.Get(id)));
    }

    private static dynamic GetDetail(DemographicDetail detail, string id)
    {
      dynamic d = new ExpandoObject();
      d.Id = id;
      d.Name = string.Format("{0}. {1}, {2} ", detail.Salutation, detail.LastName, detail.FirstName);
      return d;
    }

    public IEnumerable<dynamic> GetUserDetails(IEnumerable<User> users)
    {
      List<dynamic> details = new List<dynamic>();
      foreach (User user in users.Where(x => !string.IsNullOrWhiteSpace(x.LinkedId)))
      {
        dynamic d;
        switch (user.Role)
        {
          case UserRole.Lead:
            details.Add(GetDetail(_leadWebService.Get(user.LinkedId), user.Id));
            break;
          case UserRole.Consultant:
            details.Add(GetDetail(_instructorWebService.Get(user.LinkedId), user.Id));
            break;
          case UserRole.Admin:
          case UserRole.Marketing:
          case UserRole.Sales:
          case UserRole.Client:
          case UserRole.Finance:
          case UserRole.Operations:
          case UserRole.Support:
          case UserRole.ServerAccess:
          case UserRole.Accounting:
          case UserRole.Reporting:
          case UserRole.PowerUser:
            details.Add(GetDetail(_internalUserWebService.Get(user.LinkedId), user.Id));
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
      return details;
    }

    public IEnumerable<dynamic> GetUserDetails()
    {
      return GetUserDetails(_userWebService.Get((int?) null));
    }
  }

  public interface IuserExtentions
  {
    IEnumerable<dynamic> GetUserDetails(IEnumerable<User> users);
    dynamic GetUserDetails(User user);
    IEnumerable<dynamic> GetUserDetails(IEnumerable<string> ids);
    IEnumerable<dynamic> GetUserDetails();
    dynamic GetUserDetails(string id);
  }

  public class WebService<T> : IWebService<T> where T : class
  {
    private static string GetName()
    {
      return typeof (T).Name.Replace("Entity", string.Empty);
    }

    private static Response GetEntities(string criteria)
    {
      Response response = new WebRequest().HttpMethod(HttpMethod.Get)
          .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], GetName(), criteria))
          .ContentType(ContentType.Json)
          .GetResponse();
      return response.StatusCode == HttpStatusCode.OK ? response : null;
    }

    private static Response CreateUpdateEntity(T entity, HttpMethod httpMethod, HttpStatusCode statusCode)
    {
      Response response = new WebRequest().HttpMethod(httpMethod)
        .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], GetName(), string.Empty))
        .ContentType(ContentType.Json)
        .PostBody(JsonConvert.SerializeObject(entity)).PostResponse();
      return response.StatusCode == statusCode ? response : null;
    }

    private static Response DeleteEntity(string criteria)
    {
      Response response = new WebRequest().HttpMethod(HttpMethod.Delete)
        .Url(string.Format(ConfigurationManager.AppSettings["baseUri"], GetName(), criteria))
        .ContentType(ContentType.Json).PostResponse();
      return response.StatusCode == HttpStatusCode.OK ? response : null;
    }

    private static Response PostEntity(T entity)
    {
      return CreateUpdateEntity(entity, HttpMethod.Post, HttpStatusCode.Created);
    }

    private static Response PutEntity(T entity)
    {
      return CreateUpdateEntity(entity, HttpMethod.Put, HttpStatusCode.OK);
    }

    private static IEnumerable<T> SerializeCollection(Response response)
    {
      using (StreamReader reader = new StreamReader(response.Content))
      {
        return JsonConvert.DeserializeObject<IEnumerable<T>>(reader.ReadToEnd());
      }
    }

    private static T Serialize(Response response)
    {
      using (StreamReader reader = new StreamReader(response.Content))
      {
        return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
      }
    }

    public virtual IEnumerable<T> Get(int? count)
    {
      Response response = GetEntities(count.HasValue ? string.Format("?count={0}", count.Value) : "?count");
      return response != null ? SerializeCollection(response) : null;
    }

    public virtual IEnumerable<T> Search(string searchString)
    {
      Response response = GetEntities(string.Format("?searchString={0}", searchString));
      return response != null ? SerializeCollection(response) : null;
    }

    public virtual T Get(string id)
    {
      Response response = GetEntities(string.Format("/{0}", id));
      return response != null ? SerializeCollection(response).Single() : null;
    }

    public virtual T Create(T resource)
    {
      return Serialize(PostEntity(resource));
    }

    public virtual T Update(T resource)
    {
      return Serialize(PutEntity(resource));
    }

    public virtual void Delete(string id)
    {
      Response response = DeleteEntity(string.Format("/{0}", id));
      if (response.StatusCode != HttpStatusCode.OK)
        throw new InvalidDataException("Failed to delete lead");
    }
  }
}
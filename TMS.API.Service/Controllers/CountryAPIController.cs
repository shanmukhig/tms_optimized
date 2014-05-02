using System;
using System.Net.Http;
using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class CountryAPIController : CustomController<Country>
  {
    public CountryAPIController(IDomainService<Country> countryDomainService) : base(countryDomainService)
    {
    }

    public override HttpResponseMessage Create(Country resource)
    {
      throw new NotImplementedException();
    }

    public override HttpResponseMessage Delete(string id)
    {
      throw new NotImplementedException();
    }

    //public override HttpResponseMessage GetOne(string id)
    //{
    //  throw new NotImplementedException();
    //}

    public override HttpResponseMessage Update(Country resource)
    {
      throw new NotImplementedException();
    }
  }
}
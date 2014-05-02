using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CountryDomainService : DomainService<Country>
  {
    public CountryDomainService(IDataProvider<Country> countryDataProvider) : base(countryDataProvider)
    {
    }
  }
}
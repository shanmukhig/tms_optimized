using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class ContactDomainService : DomainService<Contact>
  {
    public ContactDomainService(IDataProvider<Contact> dataProvider) : base(dataProvider)
    {
    }
  }
}
using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class ContactAPIController : CustomController<Contact>
  {
    public ContactAPIController(IDomainService<Contact> domainService) : base(domainService)
    {
    }
  }
}

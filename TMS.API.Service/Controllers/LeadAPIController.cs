using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class LeadAPIController : CustomController<Lead>
  {
    public LeadAPIController(IDomainService<Lead> leadDomainService) : base(leadDomainService)
    {
    }
  }
}
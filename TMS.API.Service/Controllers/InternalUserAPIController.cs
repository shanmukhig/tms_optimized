using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
    public class InternalUserAPIController : CustomController<InternalUser>
    {
      public InternalUserAPIController(IDomainService<InternalUser> domainService) : base(domainService)
      {
      }
    }
}

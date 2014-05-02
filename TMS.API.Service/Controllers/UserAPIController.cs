using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class UserAPIController : CustomController<User>
  {
    public UserAPIController(IDomainService<User> userDomainService) : base(userDomainService)
    {
    }
  }
}
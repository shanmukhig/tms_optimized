using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class ActivityAPIController : CustomController<ActivityEntity>
  {
    public ActivityAPIController(IDomainService<ActivityEntity> activityDomainService):base(activityDomainService)
    {
    }
  }
}
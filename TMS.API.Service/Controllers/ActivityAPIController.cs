using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class ActivityAPIController : CustomController<Activity>
  {
    public ActivityAPIController(IDomainService<Activity> activityDomainService):base(activityDomainService)
    {
    }
  }
}
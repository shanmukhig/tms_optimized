using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class ActivityDomainService : DomainService<Activity>
  {
    public ActivityDomainService(IDataProvider<Activity> activityProvider) : base(activityProvider)
    {
    }
  }
}
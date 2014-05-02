using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class ActivityDomainService : DomainService<ActivityEntity>
  {
    public ActivityDomainService(IDataProvider<ActivityEntity> activityProvider) : base(activityProvider)
    {
    }
  }
}
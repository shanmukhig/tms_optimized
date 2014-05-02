using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class InternalUserDomainService : DomainService<InternalUser>
  {
    public InternalUserDomainService(IDataProvider<InternalUser> dataProvider)
      : base(dataProvider)
    {
    }
  }
}
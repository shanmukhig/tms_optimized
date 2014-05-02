using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class LeadDomainService : DomainService<Lead>
  {
    public LeadDomainService(IDataProvider<Lead> leadDataProvider) : base(leadDataProvider)
    {
    }
  }
}
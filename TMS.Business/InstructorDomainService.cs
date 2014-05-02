using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class InstructorDomainService : DomainService<Instructor>
  {
    public InstructorDomainService(IDataProvider<Instructor> dataProvider) : base(dataProvider)
    {
    }
  }
}

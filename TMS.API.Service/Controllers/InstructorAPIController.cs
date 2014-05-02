using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
    public class InstructorAPIController : CustomController<Instructor>
    {
      public InstructorAPIController(IDomainService<Instructor> instructorDomainService) : base(instructorDomainService)
      {
      }
    }
}

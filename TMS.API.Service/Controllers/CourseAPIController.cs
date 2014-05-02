using TMS.Business;
using TMS.Entities;

namespace TMS.API.Service.Controllers
{
  public class CourseAPIController : CustomController<Course>
  {
    public CourseAPIController(IDomainService<Course> courseDomainService) : base(courseDomainService)
    {
    }
  }
}
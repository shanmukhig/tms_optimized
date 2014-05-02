using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
    public class ContactController : CustomController<Entities.Contact>
    {
      public ContactController(IWebService<Contact> tService) : base(tService)
      {
      }
    }
}

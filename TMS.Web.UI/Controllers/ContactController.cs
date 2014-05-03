
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
    public class ContactController : CustomController<Entities.Contact>
    {
      private readonly IWebService<Contact> _contactWebService;

      public ContactController(IWebService<Contact> contactWebService) : base(contactWebService)
      {
        _contactWebService = contactWebService;
      }

      public override ActionResult Details(string id)
      {
        return View(_contactWebService.Get(id));
      }

      public override ActionResult Create()
      {
        return View(new Contact());
      }

      public override ActionResult Edit(string id)
      {
        return View(_contactWebService.Get(id));
      }
    }
}

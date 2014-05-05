
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
    public class ContactController : CustomController<Contact>
    {
      private readonly IWebService<Contact> _contactWebService;
      private readonly IuserExtentions _userExtentions;
      private readonly IWebService<Country> _countryWebService;

      public ContactController(IWebService<Contact> contactWebService, IuserExtentions userExtentions, IWebService<Country> countryWebService) : base(contactWebService, userExtentions)
      {
        _contactWebService = contactWebService;
        _userExtentions = userExtentions;
        _countryWebService = countryWebService;
      }

      public override ActionResult Index()
      {
        ViewBag.Countries = _countryWebService.Get((int?) null);
        return base.Index();
      }

      public override ActionResult Details(string id)
      {
        Contact contact = _contactWebService.Get(id);
        ViewBag.Details = _userExtentions.GetUserDetails(contact.ReferredBy);
        ViewBag.Country = _countryWebService.Get(contact.Country);
        return View(contact);
      }

      private void SetupCreateEdit()
      {
        ViewBag.Details = _userExtentions.GetUserDetails();
        ViewBag.Countries = _countryWebService.Get((int?)null);
      }

      public override ActionResult Create()
      {
        SetupCreateEdit();
        return View(new Contact());
      }

      public override ActionResult Edit(string id)
      {
        SetupCreateEdit();
        return View(_contactWebService.Get(id));
      }

      [HttpPost]
      public override ActionResult Create(Contact entity)
      {
        try
        {
          _contactWebService.Create(entity);
          return null;
        }
        catch
        {
          return View("Create", entity);
        }
      }

      [HttpPost]
      public override ActionResult Edit(Contact entity)
      {
        try
        {
          _contactWebService.Update(entity);
          return null;
        }
        catch
        {
          return View("Edit", entity);
        }
      }
    }
}

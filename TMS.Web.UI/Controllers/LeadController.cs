using System.Collections.Generic;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Entities.Enum;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class LeadController : CustomController<Lead>
  {
    private readonly IWebService<Lead> _leadService;

    public LeadController(IWebService<Lead> leadService, IWebService<User> userService,
      IWebService<Course> courseWebService, IWebService<Country> countryWebService) : base(leadService)
    {
      _leadService = leadService;
      IEnumerable<User> users = userService.Get((int?) null);
      IEnumerable<Country> countries = countryWebService.Get((int?) null);
      IEnumerable<Course> courses = courseWebService.Get((int?) null);
      ViewBag.Courses = courses;
      ViewBag.Users = users;
      ViewBag.Countries = countries;
    }

    //
    // GET: /Leads/

    //
    // GET: /Leads/Details/5

    public ActionResult Details(string id)
    {
      Lead lead = _leadService.Get(id);
      //ViewBag.ReferredBy = _userService.Get(lead.ReferredBy);
      return View("Details", lead);
    }

    //
    // GET: /Leads/Create

    public ActionResult Create()
    {
      Lead lead = new Lead();
      return View("Create", lead);
    }

    //
    // POST: /Leads/Create

    [HttpPost]
    public ActionResult CreateLead(Lead lead)
    {
      try
      {
        return View("Create", _leadService.Create(lead));
      }
      catch
      {
        return View("Create", lead);
      }
    }

    //
    // GET: /Leads/Edit/5

    public ActionResult Edit(string id)
    {
      Lead lead = _leadService.Get(id);
      return View("Edit", lead);
    }

    //
    // POST: /Leads/Edit/5

    [HttpPost]
    public ActionResult EditLead(Lead lead)
    {
      try
      {
        _leadService.Update(lead);
        return null;
      }
      catch
      {
        return View("Edit", _leadService.Get(lead.Id));
      }
    }

    //
    // GET: /Leads/Delete/5
  }
}

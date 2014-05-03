using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Entities.Enum;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class LeadController : CustomController<Lead>
  {
    private readonly IWebService<Lead> _leadService;
    private readonly IWebService<Course> _courseWebService;
    private readonly IWebService<Country> _countryWebService;
    private readonly IuserExtentions _userExtentions;

    public LeadController(IWebService<Lead> leadService, //IWebService<User> userService,
      IWebService<Course> courseWebService, 
      IWebService<Country> countryWebService, IuserExtentions userExtentions) : base(leadService)
    {
      _leadService = leadService;
      _courseWebService = courseWebService;
      _countryWebService = countryWebService;
      _userExtentions = userExtentions;
      //IEnumerable<User> users = userService.Get((int?) null);
      //IEnumerable<Country> countries = countryWebService.Get((int?) null);
      //IEnumerable<Course> courses = courseWebService.Get((int?) null);
      //ViewBag.Courses = courses;
      //ViewBag.Users = users;
      //ViewBag.Countries = countries;
    }

    public override ActionResult Index()
    {
      ViewBag.Countries = _countryWebService.Get((int?) null);
      return base.Index();
    }

    //
    // GET: /Leads/

    //
    // GET: /Leads/Details/5

    public override ActionResult Details(string id)
    {
      Lead lead = _leadService.Get(id);
      ViewBag.Details = _userExtentions.GetUserDetails(new List<string> {lead.AssignedTo, lead.ReferredBy});
      ViewBag.Country = _countryWebService.Get(lead.Country);
      ViewBag.Courses = (from c in lead.Courses select _courseWebService.Get(c.CourseId)).ToList();
      return View("Details", lead);
    }

    //
    // GET: /Leads/Create

    public override ActionResult Create()
    {
      Lead lead = new Lead();
      SetupCreateEdit();
      return View("Create", lead);
    }

    private void SetupCreateEdit()
    {
      ViewBag.Details = _userExtentions.GetUserDetails();
      ViewBag.Countries = _countryWebService.Get((int?) null);
      ViewBag.Courses = _courseWebService.Get((int?) null);
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

    public override ActionResult Edit(string id)
    {
      Lead lead = _leadService.Get(id);
      SetupCreateEdit();
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

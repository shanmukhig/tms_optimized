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
      SetupCourse(lead);
      return View("Details", lead);
    }

    //
    // GET: /Leads/Create

    public override ActionResult Create()
    {
      Lead lead = new Lead();
      SetupCreateEdit(lead);
      return View("Create", lead);
    }

    private void SetupCourse(Lead lead)
    {
      List<Course> courses = new List<Course>();
      if (lead.Courses != null && lead.Courses.Any())
      {
        foreach (CourseRequested courseRequested in lead.Courses.Where(courseRequested => courses.All(x => x.Id != courseRequested.CourseId)))
          courses.Add(_courseWebService.Get(courseRequested.CourseId));
        ViewBag.Courses = courses;
      }

    }

    private void SetupCreateEdit(Lead lead)
    {
      ViewBag.Details = _userExtentions.GetUserDetails();
      ViewBag.Countries = _countryWebService.Get((int?) null);
      SetupCourse(lead);
    }

    //
    // POST: /Leads/Create

    [HttpPost]
    public override ActionResult Create(Lead lead)
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
      SetupCreateEdit(lead);
      return View("Edit", lead);
    }

    //
    // POST: /Leads/Edit/5

    [HttpPost]
    public override ActionResult Edit(Lead lead)
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

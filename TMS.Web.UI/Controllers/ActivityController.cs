using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class ActivityController : CustomController<Activity>
  {
    private readonly IWebService<Activity> _activityWebService;
    private readonly IuserExtentions _userExtentions;

    public ActivityController(IWebService<Activity> activityWebService, IuserExtentions userExtentions) : base(activityWebService)
    {
      _activityWebService = activityWebService;
      _userExtentions = userExtentions;
    }

    public override ActionResult Index()
    {
      IEnumerable<Activity> activities = _activityWebService.Get((int?) null);
      ViewBag.Details = _userExtentions.GetUserDetails(activities.Select(x => x.AssignedTo)).ToList();
      ViewData["Activitys"] = activities;
      return View();
    }

    public override ActionResult Details(string id)
    {
      Activity activity = _activityWebService.Get(id);
      ViewBag.Details = _userExtentions.GetUserDetails(activity.AssignedTo);
      return View("Details", activity);
    }

    private void SetupCreateEdit()
    {
      ViewBag.Details = _userExtentions.GetUserDetails();
    }

    public override ActionResult Create()
    {
      SetupCreateEdit();
      return View(new Activity());
    }

    public override ActionResult Edit(string id)
    {
      SetupCreateEdit();
      return View(_activityWebService.Get(id));
    }

    [HttpPost]
    public override ActionResult Create(Activity activity)
    {
      try
      {
        _activityWebService.Create(activity);
        return null;
      }
      catch (Exception)
      {
        return View("Create", activity);
      }
    }

    [HttpPost]
    public override ActionResult Edit(Activity activity)
    {
      try
      {
        _activityWebService.Update(activity);
        return null;
      }
      catch (Exception)
      {
        return View("Edit", activity);
      }
    }
  }
}

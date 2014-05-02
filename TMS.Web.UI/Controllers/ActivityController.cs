using System;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class ActivityController : CustomController<ActivityEntity>
  {
    private readonly IWebService<ActivityEntity> _activityWebService;

    public ActivityController(IWebService<ActivityEntity> activityWebService) : base(activityWebService)
    {
      _activityWebService = activityWebService;
    }

    //public override ActionResult Index()
    //{
    //  return View();
    //}

    public ActionResult Details(string id)
    {
      return View("Details", _activityWebService.Get(id));
    }

    public ActionResult Create()
    {
      return View(new ActivityEntity());
    }

    public ActionResult Edit(string id)
    {
      return View(_activityWebService.Get(id));
    }

    public ActionResult CreateActivity(ActivityEntity activityEntity)
    {
      try
      {
        _activityWebService.Create(activityEntity);
        return null;
      }
      catch (Exception)
      {
        return View("Create", activityEntity);
      }
    }

    public ActionResult EditActivity(ActivityEntity activityEntity)
    {
      try
      {
        _activityWebService.Update(activityEntity);
        return null;
      }
      catch (Exception)
      {
        return View("Edit", activityEntity);
      }
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TMS.Entities;
using TMS.Entities.Enum;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public abstract class CustomController<T> : Controller where T : BaseEntity
  {
    private readonly IuserExtentions _userExtentions;
    private readonly IWebService<T> _tService;

    protected CustomController(IWebService<T> tService)
    {
      ViewBag.ControllerName = GetControllerName();
      _tService = tService;
    }

    protected CustomController(IWebService<T> tService, IuserExtentions userExtentions) : this(tService)
    {
      _userExtentions = userExtentions;
    }

    private static string GetControllerName()
    {
      return typeof (T).Name.Replace("Entity", string.Empty);
    }

    private static string GetName()
    {
      return string.Format("{0}s", GetControllerName());
    }

    public abstract ActionResult Details(string id);
    public abstract ActionResult Create();
    public abstract ActionResult Edit(string id);

    public virtual ActionResult Index()
    {
      IEnumerable<T> enumerable = _tService.Get((int?) null);
      if (_userExtentions != null)
      {
        ViewBag.Details = _userExtentions.GetUserDetails(enumerable as IEnumerable<User>);
      }
      ViewData[GetName()] = enumerable;
      return View();
    }

    public virtual ActionResult Search(string searchString)
    {
      ViewData[GetName()] = _tService.Search(searchString);
      return View("Index");
    }

    public virtual ActionResult Enable(string id)
    {
      UpdateStatus(id, Status.Active);
      return null;
    }

    public virtual ActionResult Delete(string id)
    {
      _tService.Delete(id);
      return null;
    }

    public virtual ActionResult Disable(string id)
    {
      UpdateStatus(id, Status.Inactive);
      return null;
    }

    private void UpdateStatus(string id, Status status)
    {
      T t = _tService.Get(id);
      t.Status = status;
      _tService.Update(t);
    }
  }
}
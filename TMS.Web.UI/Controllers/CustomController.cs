using System.Web.Mvc;
using TMS.Entities;
using TMS.Entities.Enum;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public abstract class CustomController<T> : Controller where T : BaseEntity
  {
    private readonly IWebService<T> _tService;

    protected CustomController(IWebService<T> tService)
    {
      ViewBag.ControllerName = GetControllerName();
      _tService = tService;
    }

    private static string GetControllerName()
    {
      return typeof (T).Name.Replace("Entity", string.Empty);
    }

    private static string GetName()
    {
      return string.Format("{0}s", GetControllerName());
    }

    public virtual ActionResult Index()
    {
      ViewData[GetName()] = _tService.Get((int?) null);
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